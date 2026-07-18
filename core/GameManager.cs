using Godot;
using System;

// Global game-state singleton (Autoload). Owns run-level progression and economy.
public partial class GameManager : Node
{
    public int CurrentRound { get; set; } = 1;
    public int TotalScrap { get; set; } = 0;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }

    // Awards Scrap (e.g., from a kill).
    public void AddScrap(int amount)
    {
        TotalScrap += amount;
        GD.Print($"Scrap Earned! Total: {TotalScrap}");
    }

    // Attempts to spend Scrap. Returns true only if the player could afford it.
    public bool TrySpendScrap(int amount)
    {
        if (TotalScrap >= amount)
        {
            TotalScrap -= amount;
            GD.Print($"Scrap Spent! Total: {TotalScrap}");
            return true;
        }

        GD.Print("Not enough Scrap!");
        return false;
    }
}
