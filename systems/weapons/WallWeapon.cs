using Godot;
using System;

// A fixed "wall buy" pickup. The player looks at it and interacts to purchase.
// Attached to the Area3D root of WallWeapon.tscn (in the "Interactable" group).
public partial class WallWeapon : Area3D
{
    [Export] public string WeaponName = "Weapon";
    [Export] public int ScrapCost = 500;

    public bool IsPurchased = false;

    private Label3D _label;

    public override void _Ready()
    {
        _label = GetNodeOrNull<Label3D>("Label3D");
        if (_label != null)
            _label.Text = WeaponName + " [" + ScrapCost + " Scrap]";
    }

    // Handles a player purchase interaction. First buy takes full price and flips
    // the label to the (cheaper) ammo-refill prompt; subsequent buys refill ammo.
    public void OnInteract(Node3D playerNode)
    {
        GameManager gameManager = GetNode<GameManager>("/root/GameManager");
        if (playerNode is not PlayerController player)
            return;

        if (!IsPurchased)
        {
            if (gameManager.TrySpendScrap(ScrapCost))
            {
                IsPurchased = true;
                player.RefillAmmo();
                if (_label != null)
                    _label.Text = WeaponName + " Ammo [" + (ScrapCost / 2) + " Scrap]";
            }
        }
        else
        {
            if (gameManager.TrySpendScrap(ScrapCost / 2))
                player.RefillAmmo();
        }
    }
}
