﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public static float constantMovement = 3.0f;
    float leftOutOfBounds = -30.0f;
    

    void Update()
    {
        MoveToLeft();
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if(transform.position.x <= leftOutOfBounds)
        {
            Destroy(gameObject);
        }
    }

    void MoveToLeft()
    {
        transform.position = new Vector3(transform.position.x - (constantMovement * Time.deltaTime), transform.position.y);
    }
}
