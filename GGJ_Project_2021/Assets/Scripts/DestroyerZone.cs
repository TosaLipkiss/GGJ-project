using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerZone : MonoBehaviour
{
    public GameObject gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            Debug.Log("Game Over!");
        }
    }
}

