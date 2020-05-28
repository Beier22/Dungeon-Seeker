using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Dungeon001");
    }
    public void LoadGame()
    {
        Player.state = LoadState.LOAD;
        PlayerData data = SaveData.LoadPlayer();
        SceneManager.LoadScene(data.level);
    }
    public void Options()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}