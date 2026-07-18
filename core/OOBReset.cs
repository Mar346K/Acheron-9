using Godot;
using System;

// Out-of-bounds catch net. Any body that falls into this Area3D is teleported
// back to the spawn point. Attached to the "OOB_Reset" Area3D.
public partial class OOBReset : Area3D
{
    [Export] public Vector3 SpawnPoint = new Vector3(0, 2, 0);

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node3D body)
    {
        if (!body.IsInGroup("Player") && body.Name != "Player")
            return;

        // Kill any residual fall velocity so the respawn is clean.
        if (body is CharacterBody3D characterBody)
            characterBody.Velocity = Vector3.Zero;

        body.GlobalPosition = SpawnPoint;
    }
}
