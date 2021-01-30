using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioClip music;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}
