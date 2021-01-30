﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform pickUpSpawnPoint;

    public Object[] middleGroundObjects;
    public Object[] obstacles;
    public Object[] pickupObjects;

    //Data for govern spawners
    float timeSinceMiddleGroundSpawn;
    float timeBetweenMiddleGroundSpawn;
    float timeSinceObstacleSpawn;
    float timeBetweenObstacleSpawn;

    float pickUpSpawnTimer = 0f;
    float pickUpSpawnInterval = 2f;

    int indexToSpawn;


    void Start()
    {
        middleGroundObjects = Resources.LoadAll("Prefabs/Middleground", typeof(GameObject));
        obstacles = Resources.LoadAll("Prefabs/Obstacles", typeof(GameObject));
        pickupObjects = Resources.LoadAll("Prefabs/Pickup", typeof(GameObject));

        timeSinceMiddleGroundSpawn = 0;
        timeBetweenMiddleGroundSpawn = 10;

        timeSinceObstacleSpawn = 0;
        timeBetweenObstacleSpawn = 3;
    }

    void Update()
    {
        SpawnPickUp();

        MiddleGroundSpawn();

        ObstacleSpawn();
    }

    void SpawnPickUp()
    {
        pickUpSpawnTimer += Time.deltaTime;
        if(pickUpSpawnTimer >= pickUpSpawnInterval)
        {
            int randomPickUp = Random.Range(0, pickupObjects.Length);
            Instantiate(pickupObjects[randomPickUp], pickUpSpawnPoint.position, Quaternion.identity);
            pickUpSpawnTimer = 0f;
        }
    }

    void MiddleGroundSpawn()
    {
        if (timeSinceMiddleGroundSpawn >= timeBetweenMiddleGroundSpawn)
        {
            indexToSpawn = Random.Range(0, middleGroundObjects.Length - 1);

            Instantiate(middleGroundObjects[indexToSpawn], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);

            timeBetweenMiddleGroundSpawn = 10 + Random.Range(-3f, +3f);

            timeSinceMiddleGroundSpawn = 0f;
        }
        else
        {
            timeSinceMiddleGroundSpawn += Time.deltaTime;
        }
    }

    void ObstacleSpawn()
    {
        if (timeSinceObstacleSpawn >= timeBetweenObstacleSpawn)
        {
            indexToSpawn = Random.Range(0, obstacles.Length - 1);

            Instantiate(obstacles[indexToSpawn], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);

            timeBetweenObstacleSpawn = 3.0f + Random.Range(-1.2f, +1.0f);

            timeSinceObstacleSpawn = 0f;
        }
        else
        {
            timeSinceObstacleSpawn += Time.deltaTime;
        }
    }
}