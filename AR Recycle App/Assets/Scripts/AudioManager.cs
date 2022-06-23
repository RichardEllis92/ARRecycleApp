using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource slash;
    public AudioSource music;

    private void Awake()
    {
        instance = this;
    }
    public void PlaySlash()
    {
        slash.Stop();
        slash.Play();
    }

    public void PlayMusic()
    {
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }
}
