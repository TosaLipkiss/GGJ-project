using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] middleGroundObjects;
    int amountOfMiddleGroundObject = 3;

    public GameObject[] obstacles;
    int amountOfObstacle = 3;

    public GameObject[] pickupObjects;
    int amountOfPickup = 1;

    //Data for govern spawners
    float timeSinceMiddleGroundSpawn;
    float timeBetweenMiddleGroundSpawn;
    float timeToPickupSpawn;
    float timeToObstacleSpawn;


    void Start()
    {
        middleGroundObjects = new GameObject[amountOfMiddleGroundObject];

        middleGroundObjects[0] = Resources.Load<GameObject>("Prefabs/Middleground/Middleground_Alley01");
        middleGroundObjects[1] = Resources.Load<GameObject>("Prefabs/Middleground/Middleground_Alley02");
        middleGroundObjects[2] = Resources.Load<GameObject>("Prefabs/Middleground/Middleground_Alley03");

        timeSinceMiddleGroundSpawn = 0;
        timeBetweenMiddleGroundSpawn = 10;
    }

    void Update()
    {
        if (timeSinceMiddleGroundSpawn >= timeBetweenMiddleGroundSpawn)
        {
            Instantiate(middleGroundObjects[0], transform.position, Quaternion.identity);
            timeSinceMiddleGroundSpawn = 0;
        }
        else
        {
            timeSinceMiddleGroundSpawn += Time.deltaTime;
        }
    }
}