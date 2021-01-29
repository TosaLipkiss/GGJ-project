using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Object[] middleGroundObjects;

    public Object[] obstacles;

    public Object[] pickupObjects;

    //Data for govern spawners
    float timeSinceMiddleGroundSpawn;
    float timeBetweenMiddleGroundSpawn;
    float timeToPickupSpawn;
    float timeToObstacleSpawn;

    int indexToSpawn;


    void Start()
    {
        middleGroundObjects = Resources.LoadAll("Prefabs/Middleground", typeof(GameObject));

        obstacles = Resources.LoadAll("Prefabs/Obstacles", typeof(GameObject));

        pickupObjects = Resources.LoadAll("Prefabs/Pickup", typeof(GameObject));

        timeSinceMiddleGroundSpawn = 0;
        timeBetweenMiddleGroundSpawn = 10;
    }

    void Update()
    {
        if (timeSinceMiddleGroundSpawn >= timeBetweenMiddleGroundSpawn)
        {
            indexToSpawn = Random.Range(0, middleGroundObjects.Length - 1);
            
            Instantiate(middleGroundObjects[indexToSpawn], transform.position, Quaternion.identity);
            timeSinceMiddleGroundSpawn = 0;

            timeBetweenMiddleGroundSpawn = 10 + Random.Range(-3f, +3f);
        }
        else
        {
            timeSinceMiddleGroundSpawn += Time.deltaTime;
        }
    }
}