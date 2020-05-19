using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour

{
    
    public AudioClip jump;
    public AudioClip attack;
    public AudioClip magic;


    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        sound.clip = attack;
        sound.Play();
    }
    public void PlayMagicSound()
    {
        sound.clip = magic;
        sound.Play();
    }
    public void PlayJumpSound()
    {
        sound.clip = jump;
        sound.Play();
    }

}
