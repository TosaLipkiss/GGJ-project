using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 move;
    PlayerMovement playerMovement;
    float velocity = 3;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        move = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("move left");
            move.x += -velocity;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            move.x += velocity;
        }

        playerMovement.MovePlayer(move);
        move = Vector3.zero;
    }
}
