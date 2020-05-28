using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 8;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        Debug.Log("Adding " + item.name + " to inventory!");
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void LoadInventoryData()
    {
        InventoryData data = SaveData.LoadInventoryItems();

        space = data.space;

        LoadFromResources(data.itemNames.ToList());
    }

    public void LoadPersistedData(List<string> itemNames)
    {
        LoadFromResources(itemNames);
    }

    private void LoadFromResources(List<string> itemNames)
    {
        foreach (var name in itemNames)
        {
            Item item = Resources.Load(name, typeof(Item)) as Item;

            Debug.Log("item name: " + item.name);
            if (item != null)
            {
                if (Add(Resources.Load<Item>(name)))
                {
                    Debug.Log("yey");
                }
                else
                {
                    Debug.LogError("fuck");
                }
            }
        }
    }
}
