using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public static class SaveData
{
    private static string path = Application.persistentDataPath;

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path + "/player.doggo", FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

        //EditorUtility.DisplayDialog("", "Game Saved", "OK");
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(path + "/player.doggo"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + "/player.doggo", FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveInventoryItems()
    {
        //List<string> json = new List<string>();

        //foreach (var item in Inventory.instance.items)
        //{
        //    json.Add(JsonUtility.ToJson(item));
        //}

        InventoryData data = new InventoryData();

        Debug.Log("item1: " + data.itemNames[0]);
        Debug.Log("item2: " + data.itemNames[1]);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path + "/inventory.doggo", FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InventoryData LoadInventoryItems()
    {

        if (File.Exists(path + "/inventory.doggo"))
        {
            //List<Item> items = new List<Item>();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + "/inventory.doggo", FileMode.Open);
            InventoryData data = formatter.Deserialize(stream) as InventoryData;
            stream.Close();
            //foreach (var item in json)
            //{
            //    Item it = JsonUtility.FromJson<Item>(item);
            //    items.Add(it);
            //}
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
