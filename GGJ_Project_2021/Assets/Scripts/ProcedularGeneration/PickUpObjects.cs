using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    float power;
    Rigidbody2D rb;

    void Start()
    {
        TimeScript timeScript = GameObject.Find("LinearTimer").GetComponent<TimeScript>();
        if(timeScript.currentTime > 100)
        {
            Debug.Log("using timescript");
            power = Random.Range(5f, 8f);
        }
        else if (timeScript.currentTime > 75)
        {
            Debug.Log("using timescript2");
            power = Random.Range(4f, 7f);
        }
        else if (timeScript.currentTime > 50)
        {
            Debug.Log("using timescript3");
            power = Random.Range(3f, 6f);
        }
        else
        {
            power = Random.Range(2f, 5f);
        }

        rb = GetComponent<Rigidbody2D>();
        Vector2 upLeft = new Vector2(Random.Range(-0.4f, -0.1f), 1f);
        rb.AddForce(upLeft * power, ForceMode2D.Impulse);
    }
}
