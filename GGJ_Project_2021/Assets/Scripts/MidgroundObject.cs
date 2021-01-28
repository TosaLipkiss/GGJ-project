using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Debug.Log("Destroys streetlamp");

            Destroy(gameObject);
        }
    }
}
