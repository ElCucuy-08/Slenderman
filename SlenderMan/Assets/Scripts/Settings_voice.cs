using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_voice : MonoBehaviour
{
    private AudioSource audioSRC;
    private float MusicVolume = 1f;

    private void Start()
    {
        audioSRC = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSRC.volume= MusicVolume;
    }
    public void SetVolume(float vol)
    {
        MusicVolume= vol;
    }
}
