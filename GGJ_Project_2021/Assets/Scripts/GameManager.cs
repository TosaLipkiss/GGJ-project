using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float constantMovement = 3.0f;
    public float leftOutOfBounds = -13.0f;

    void Update()
    {
        transform.Translate(Vector2.left * constantMovement * Time.deltaTime);

        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if(transform.position.x <= leftOutOfBounds)
        {
            Destroy(gameObject);

            Debug.Log("Object destroyed by GameManager");
        }
    }
}
