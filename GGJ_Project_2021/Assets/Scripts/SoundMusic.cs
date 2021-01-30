using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusic : MonoBehaviour
{
    public AudioClip music;
    public AudioClip truck;
    public AudioSource audioSource;
    public AudioSource truckAudioSource;

    private void Start()
    {
        truckAudioSource.clip = truck;
        truckAudioSource.Play();
        audioSource.clip = music;
        audioSource.Play();
    }
}
