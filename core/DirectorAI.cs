using Godot;
using System;

// Swarm-intelligence spawn director (Autoload). Manages round pacing and
// enforces the active machine cap while feeding enemies toward the player.
public partial class DirectorAI : Node
{
    // Maximum machines allowed alive at once in Solo play.
    public const int SoloSpawnLimit = 18;

    // Live tracking.
    public int ActiveMachineCount { get; private set; } = 0;
    public int MaxActiveMachines { get; set; } = SoloSpawnLimit;
    public int RoundSpawnsRemaining { get; set; } = 0;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
        UpdatePacing(delta);
    }

    // Called at the start of each wave to seed the spawn array for the round.
    public void StartRound(int round)
    {
        // TODO: compute RoundSpawnsRemaining from round scaling curve.
    }

    // Adjusts spawn cadence based on player proximity, round, and pressure.
    private void UpdatePacing(double delta)
    {
        // TODO: pacing logic.
    }

    // Attempts to spawn a machine while under the active cap.
    public void TrySpawnMachine()
    {
        if (ActiveMachineCount >= MaxActiveMachines || RoundSpawnsRemaining <= 0)
            return;

        // TODO: select ingress point + unit type, instantiate, then:
        ActiveMachineCount++;
        RoundSpawnsRemaining--;
    }

    // Hook for enemies to report their death back to the director.
    public void OnMachineDestroyed()
    {
        ActiveMachineCount = Mathf.Max(0, ActiveMachineCount - 1);
    }
}
