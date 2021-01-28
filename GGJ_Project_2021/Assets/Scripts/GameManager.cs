using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float constantMovement = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * constantMovement * Time.deltaTime);    
    }

}
