using Godot;
using System;

// First-person Bio-Kinetic movement controller.
// Handles mouselook, WASD movement, sprint (with FOV kick), a heavier-than-default
// gravity, and the Momentum Slide. HUD, weapons, and Blood Arts are intentionally
// out of scope here.
public partial class PlayerController : CharacterBody3D
{
    [ExportGroup("Movement")]
    [Export] public float WalkSpeed = 5.0f;
    [Export] public float SprintSpeed = 8.5f;
    [Export] public float JumpVelocity = 5.0f;
    [Export] public float Acceleration = 12.0f;

    [ExportGroup("Wall Jump")]
    // Horizontal shove applied away from the wall on a wall jump.
    [Export] public float WallJumpPushStrength = 7.0f;
    // Brief window after a wall jump where air control won't cancel the impulse.
    [Export] public float WallJumpControlLockTime = 0.2f;

    [ExportGroup("Ammunition")]
    public int CurrentAmmo = 30;
    public int ReserveAmmo = 90;

    [ExportGroup("Look")]
    [Export] public float MouseSensitivity = 0.003f;
    [Export(PropertyHint.Range, "40,89,1")] public float MaxPitchDegrees = 89.0f;

    [ExportGroup("Gravity")]
    // Multiplier applied on top of the project's default gravity so falls feel
    // weighty rather than floaty.
    [Export] public float GravityMultiplier = 2.2f;

    [ExportGroup("Field of View")]
    [Export] public float BaseFov = 90.0f;
    [Export] public float SprintFov = 100.0f;
    [Export] public float FovLerpSpeed = 8.0f;

    [ExportGroup("Momentum Slide")]
    [Export] public float SlideImpulse = 4.0f;
    [Export] public float SlideFriction = 6.0f;
    [Export] public float MinSlideSpeed = 3.0f;
    [Export] public float StandHeight = 2.0f;
    [Export] public float SlideHeight = 1.0f;
    [Export] public float StandHeadY = 0.6f;
    [Export] public float SlideHeadY = 0.2f;
    [Export] public float CrouchLerpSpeed = 10.0f;

    private Node3D _head;
    private Camera3D _camera;
    private CollisionShape3D _collision;
    private MeshInstance3D _mesh;
    private CapsuleShape3D _capsuleShape;
    private CapsuleMesh _capsuleMesh;
    private RayCast3D _shootRay;
    private RayCast3D _interactRay;

    private float _baseGravity;
    private bool _isSliding;
    private Vector3 _slideDirection = Vector3.Zero;
    private float _slideSpeed;
    private float _wallJumpLockTimer;

    public override void _Ready()
    {
        _head = GetNode<Node3D>("Head");
        _camera = GetNode<Camera3D>("Head/Camera3D");
        _collision = GetNode<CollisionShape3D>("CollisionShape3D");
        _mesh = GetNode<MeshInstance3D>("MeshInstance3D");

        // Duplicate so runtime height changes don't mutate the shared scene resource.
        _capsuleShape = (CapsuleShape3D)((CapsuleShape3D)_collision.Shape).Duplicate();
        _collision.Shape = _capsuleShape;
        _capsuleMesh = (CapsuleMesh)((CapsuleMesh)_mesh.Mesh).Duplicate();
        _mesh.Mesh = _capsuleMesh;

        _shootRay = GetNode<RayCast3D>("Head/Camera3D/RayCast3D");
        _interactRay = GetNode<RayCast3D>("Head/InteractRayCast");

        _baseGravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity", 9.8);

        _camera.Fov = BaseFov;
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion motion && Input.MouseMode == Input.MouseModeEnum.Captured)
        {
            // Yaw on the body, pitch on the head so movement stays horizontal.
            RotateY(-motion.Relative.X * MouseSensitivity);

            Vector3 headRot = _head.Rotation;
            headRot.X -= motion.Relative.Y * MouseSensitivity;
            float limit = Mathf.DegToRad(MaxPitchDegrees);
            headRot.X = Mathf.Clamp(headRot.X, -limit, limit);
            _head.Rotation = headRot;
        }

        if (@event.IsActionPressed("ui_cancel"))
        {
            Input.MouseMode = Input.MouseMode == Input.MouseModeEnum.Captured
                ? Input.MouseModeEnum.Visible
                : Input.MouseModeEnum.Captured;
        }
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("shoot"))
            Shoot();

        if (Input.IsActionJustPressed("interact"))
            Interact();
    }

    // Short-range interaction ray for wall buys and other "Interactable" props.
    private void Interact()
    {
        if (_interactRay == null)
            return;

        _interactRay.ForceRaycastUpdate();
        if (!_interactRay.IsColliding())
            return;

        if (_interactRay.GetCollider() is Node collider && collider.IsInGroup("Interactable"))
        {
            if (collider is WallWeapon weapon)
                weapon.OnInteract(this);
        }
    }

    // Resets the magazine to full (called on a wall-buy purchase or ammo refill).
    public void RefillAmmo()
    {
        CurrentAmmo = 30;
        GD.Print("Ammo Refilled!");
    }

    // Fires the weapon ray. A hit on the Battery weak point triggers a Capacitor
    // Bleed meltdown; a hit on the chassis body deals partial damage.
    private void Shoot()
    {
        if (_shootRay == null)
            return;

        if (CurrentAmmo <= 0)
        {
            GD.Print("Click! Out of Ammo.");
            return;
        }

        CurrentAmmo--;
        GD.Print($"Bang! Ammo: {CurrentAmmo}");

        _shootRay.ForceRaycastUpdate();
        if (!_shootRay.IsColliding())
            return;

        if (_shootRay.GetCollider() is not Node collider)
            return;

        if (collider.IsInGroup("Battery"))
        {
            // The Battery Area3D's parent is the ScrapWalker chassis.
            if (collider.GetParent() is ScrapWalkerAI batteryWalker)
                batteryWalker.TriggerBatteryMeltdown();
        }
        else if (collider is ScrapWalkerAI chassisWalker)
        {
            chassisWalker.TakeDamage(34f);
            GD.Print($"Body Shot. Health remaining: {chassisWalker.CurrentHealth}");
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;
        Vector3 velocity = Velocity;

        bool grounded = IsOnFloor();

        if (_wallJumpLockTimer > 0f)
            _wallJumpLockTimer -= dt;

        // Heavier-than-default gravity.
        if (!grounded)
            velocity.Y -= _baseGravity * GravityMultiplier * dt;

        // Jump / Wall Jump.
        if (Input.IsActionJustPressed("jump"))
        {
            if (grounded)
            {
                velocity.Y = JumpVelocity;
            }
            else if (IsOnWall())
            {
                // Kick up and away from the wall we're clinging to.
                Vector3 wallNormal = GetWallNormal();
                velocity.Y = JumpVelocity;
                velocity.X = wallNormal.X * WallJumpPushStrength;
                velocity.Z = wallNormal.Z * WallJumpPushStrength;
                _wallJumpLockTimer = WallJumpControlLockTime;
            }
        }

        Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_forward", "move_back");
        Vector3 wishDir = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

        bool wantsSprint = Input.IsActionPressed("sprint");
        bool wantsCrouch = Input.IsActionPressed("crouch");

        // Enter a slide from a grounded sprint when crouch is pressed while moving.
        if (!_isSliding && grounded && wantsSprint && wantsCrouch && wishDir != Vector3.Zero)
            StartSlide(wishDir);

        if (_isSliding)
        {
            ProcessSlide(ref velocity, wantsCrouch, grounded, dt);
        }
        else if (_wallJumpLockTimer > 0f)
        {
            // Preserve the wall-jump impulse; skip air-control override this window.
        }
        else
        {
            float targetSpeed = wantsSprint ? SprintSpeed : WalkSpeed;
            Vector3 targetHorizontal = wishDir * targetSpeed;
            velocity.X = Mathf.MoveToward(velocity.X, targetHorizontal.X, Acceleration * targetSpeed * dt);
            velocity.Z = Mathf.MoveToward(velocity.Z, targetHorizontal.Z, Acceleration * targetSpeed * dt);
        }

        Velocity = velocity;
        MoveAndSlide();

        UpdateFov(wantsSprint && !_isSliding, dt);
        UpdateCrouchVisual(dt);
    }

    private void StartSlide(Vector3 fallbackDir)
    {
        _isSliding = true;

        Vector3 horizontal = new Vector3(Velocity.X, 0, Velocity.Z);
        _slideDirection = horizontal.LengthSquared() > 0.01f ? horizontal.Normalized() : fallbackDir;

        // Preserve current momentum and add a forward impulse.
        float currentSpeed = new Vector2(Velocity.X, Velocity.Z).Length();
        _slideSpeed = Mathf.Max(SprintSpeed, currentSpeed) + SlideImpulse;
    }

    private void ProcessSlide(ref Vector3 velocity, bool wantsCrouch, bool grounded, float dt)
    {
        // Bleed off speed with friction until the slide decays or is cancelled.
        _slideSpeed = Mathf.MoveToward(_slideSpeed, 0.0f, SlideFriction * dt);
        velocity.X = _slideDirection.X * _slideSpeed;
        velocity.Z = _slideDirection.Z * _slideSpeed;

        if (_slideSpeed <= MinSlideSpeed || !wantsCrouch || !grounded)
            _isSliding = false;
    }

    private void UpdateFov(bool sprinting, float dt)
    {
        float target = sprinting ? SprintFov : BaseFov;
        _camera.Fov = Mathf.Lerp(_camera.Fov, target, FovLerpSpeed * dt);
    }

    private void UpdateCrouchVisual(float dt)
    {
        float targetHeight = _isSliding ? SlideHeight : StandHeight;
        float targetHeadY = _isSliding ? SlideHeadY : StandHeadY;

        _capsuleShape.Height = Mathf.Lerp(_capsuleShape.Height, targetHeight, CrouchLerpSpeed * dt);
        _capsuleMesh.Height = Mathf.Lerp(_capsuleMesh.Height, targetHeight, CrouchLerpSpeed * dt);

        Vector3 headPos = _head.Position;
        headPos.Y = Mathf.Lerp(headPos.Y, targetHeadY, CrouchLerpSpeed * dt);
        _head.Position = headPos;
    }
}
