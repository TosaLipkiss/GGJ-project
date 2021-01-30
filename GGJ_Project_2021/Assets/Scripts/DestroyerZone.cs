using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerZone : MonoBehaviour
{
    public AudioClip gameOverSound;
    public AudioSource audioSource;
    public AudioSource truckAudioSource;
    public AudioSource music;
    public GameObject gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            truckAudioSource.Stop();
            music.Stop();
            audioSource.PlayOneShot(gameOverSound);
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}

