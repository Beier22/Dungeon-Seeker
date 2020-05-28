using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public int space;
    public string[] itemNames;
    public InventoryData()
    {
        space = Inventory.instance.space;

        List<Item> items = Inventory.instance.items;
        itemNames = new string[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            itemNames[i] = items[i].name;
        }
    }
}
