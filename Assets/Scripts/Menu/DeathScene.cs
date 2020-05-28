using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        GetComponent<Animator>().enabled = true;
    }

    public void ResetPlayer()
    {
        player.LoadLevel();
        gameObject.SetActive(false);
    }
}
