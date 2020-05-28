using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potion : Item
{
    public int healing = 15;
    public override void Use()
    {
        base.Use();
        RemoveFromInventory();
        if ((Player.health + healing) > 100)
        {
            Player.health = 100;
            return;
        }
        Player.health += healing;
    }
}
