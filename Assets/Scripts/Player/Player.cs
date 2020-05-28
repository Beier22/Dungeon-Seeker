using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LoadState
{ 
    START = 0, LOAD = 1
}

public class Player : MonoBehaviour
{
    public static int level = 1;
    public static int health = 100;
    public static bool isAlive = true;

    public static LoadState state;

    private void Start()
    {
        if (PlayerPrefs.HasKey("item0"))
        {
            List<string> itemNames = new List<string>();
            int index = 0;
            while (PlayerPrefs.HasKey("item" + index))
            {
                itemNames.Add(PlayerPrefs.GetString("item" + index));
                PlayerPrefs.DeleteKey("item" + index);
                index++;
            }
            Inventory.instance.LoadPersistedData(itemNames);
            PlayerPrefs.Save();
        }
        if (state == LoadState.LOAD)
        {
            state = LoadState.START;
            LoadPlayer();
            Inventory.instance.LoadInventoryData();
        }
        Debug.Log("level: " + level);
    }

    public void SavePlayer()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SaveData.SavePlayer(this);
        SaveData.SaveInventoryItems();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        state = LoadState.LOAD;
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveData.LoadPlayer();

        level = data.level;
        health = data.health;
        isAlive = true;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}
