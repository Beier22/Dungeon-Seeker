using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            if (gameObject.name == "Previous_Level")
            {
                Debug.Log("Previous_Level");
                level -= 1;
                Player.level = level;
                PersistInventory();
                SceneManager.LoadScene(level);
            }
            else if (gameObject.name == "Next_Level")
            {
                Debug.Log("Next_Level");
                level += 1;
                Player.level = level;
                PersistInventory();
                SceneManager.LoadScene(level);
            }
            else if (gameObject.name == "Victory_Door")
            {
                Debug.Log("You WON");
                SceneManager.LoadScene("VictoryScene");
            }
        }
    }

    private void PersistInventory()
    {
        List<Item> items = Inventory.instance.items;

        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                PlayerPrefs.SetString("item" + i, items[i].name);
            }
            PlayerPrefs.Save();
        }
    }
}
