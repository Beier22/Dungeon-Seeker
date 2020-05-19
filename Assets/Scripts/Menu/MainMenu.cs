using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        PlayerData data = SaveData.LoadPlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + data.level);
    }
    public void Options()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}