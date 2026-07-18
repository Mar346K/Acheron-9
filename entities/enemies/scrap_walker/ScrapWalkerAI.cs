using Godot;
using System;

// Early-game "Scrap-Walker": a repurposed mining bot that creeps directly toward
// the player. Its weak point is the Cervical Hump (the "Battery" Area3D). A battery
// hit triggers a "Capacitor Bleed" — a delayed, zombie-like death.
public partial class ScrapWalkerAI : CharacterBody3D
{
    [Export] public float MoveSpeed = 1.5f;

    public float MaxHealth = 100f;
    public float CurrentHealth = 100f;
    public bool IsBleedingOut = false;
    public float BleedDPS = 50f;

    private Node3D _player;
    private float _gravity;
    private bool _isDead = false;

    public override void _Ready()
    {
        _gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity", 9.8);
        _player = FindPlayer();
    }

    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;

        // Capacitor Bleed: once triggered, health drains until the machine dies.
        if (IsBleedingOut && !_isDead)
        {
            CurrentHealth -= BleedDPS * dt;
            if (CurrentHealth <= 0f)
                Terminate();
        }

        Vector3 velocity = Velocity;

        // Keep grounded.
        if (!IsOnFloor())
            velocity.Y -= _gravity * dt;
        else if (velocity.Y < 0f)
            velocity.Y = 0f;

        if (_player == null || !IsInstanceValid(_player))
            _player = FindPlayer();

        if (_player != null)
        {
            // Creep toward the player's X/Z position only.
            Vector3 toPlayer = _player.GlobalPosition - GlobalPosition;
            toPlayer.Y = 0f;

            Vector3 dir = toPlayer.LengthSquared() > 0.0001f ? toPlayer.Normalized() : Vector3.Zero;
            velocity.X = dir.X * MoveSpeed;
            velocity.Z = dir.Z * MoveSpeed;
        }
        else
        {
            velocity.X = 0f;
            velocity.Z = 0f;
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private Node3D FindPlayer()
    {
        return GetTree().GetFirstNodeInGroup("Player") as Node3D;
    }

    // Standard damage to the health pool (e.g., chassis body shots).
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0f)
            Terminate();
    }

    // Battery weak-point hit: instantly drops to 20% and starts the bleed-out.
    public void TriggerBatteryMeltdown()
    {
        if (IsBleedingOut)
            return;

        IsBleedingOut = true;
        CurrentHealth = MaxHealth * 0.20f;
        GD.Print("Battery Destroyed! Capacitor Bleed Started!");

        // Remove the weak point so it can't be hit twice.
        GetNodeOrNull<Area3D>("Battery")?.QueueFree();
    }

    public void Terminate()
    {
        if (_isDead)
            return;

        _isDead = true;
        GD.Print("Machine Destroyed!");
        GetNode<GameManager>("/root/GameManager").AddScrap(100);
        QueueFree();
    }
}
