using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    float power;
    Rigidbody2D rb;

    void Start()
    {
        power = 5f;
        rb = GetComponent<Rigidbody2D>();
        Vector2 upLeft = new Vector2(Random.Range(-0.3f, -0.1f), 1f);
        rb.AddForce(upLeft * power, ForceMode2D.Impulse);
    }
}
