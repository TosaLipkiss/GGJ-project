using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;

    public void MovePlayer(Vector3 move)
    {
        if(move.sqrMagnitude > 0.01)
        {
            transform.position += move;
        }
    }
}