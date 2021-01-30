using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform pickUpSpawnPoint;

    public Transform groundedObstaclesSpawnPoint;
    public Transform thrownObstaclesSpawnPoint;

    public Transform standingDecorationSpawnPoint;
    
    public GameObject[] middleGroundObjects;
    public GameObject[] obstacles;
    public GameObject[] pickupObjects;
    public GameObject[] decorativeObjects;

    //Data for govern spawners
    float timeSinceMiddleGroundSpawn;
    float timeBetweenMiddleGroundSpawn;
    float timeSinceObstacleSpawn;
    float timeBetweenObstacleSpawn;

    float timeBetweenDecorativeSpawn;
    float timeSinceDecorativeSpawn;

    float pickUpSpawnTimer = 0f;
    float pickUpSpawnInterval = 10f;

    int indexToSpawn;


    void Start()
    {
        middleGroundObjects = Resources.LoadAll<GameObject>("Prefabs/Middleground");
        obstacles = Resources.LoadAll<GameObject>("Prefabs/Obstacles");
        pickupObjects = Resources.LoadAll<GameObject>("Prefabs/Pickup");
        decorativeObjects = Resources.LoadAll<GameObject>("Prefabs/Decorations");

        timeSinceMiddleGroundSpawn = 0;
        timeBetweenMiddleGroundSpawn = 8;

        timeSinceObstacleSpawn = 0;
        timeBetweenObstacleSpawn = 2;

        timeBetweenDecorativeSpawn = 2;
        timeSinceDecorativeSpawn = 0;
    }

    void Update()
    {
        SpawnPickUp();

        MiddleGroundSpawn();

        ObstacleSpawn();
    }

    void SpawnPickUp()
    {
        if(pickUpSpawnTimer >= pickUpSpawnInterval)
        {
            int randomPickUp = Random.Range(0, pickupObjects.Length);

            Instantiate(pickupObjects[randomPickUp], pickUpSpawnPoint.position, Quaternion.identity);
            pickUpSpawnTimer = 0f;
        }
        else
        {
            pickUpSpawnTimer += Time.deltaTime;
        }
    }

    void MiddleGroundSpawn()
    {
        if (timeSinceMiddleGroundSpawn >= timeBetweenMiddleGroundSpawn)
        {
            indexToSpawn = Random.Range(0, middleGroundObjects.Length - 1);

            Instantiate(middleGroundObjects[indexToSpawn], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);

            timeBetweenMiddleGroundSpawn = 8 + Random.Range(-3f, +3f);

            timeSinceMiddleGroundSpawn = 0f;
        }
        else if(timeSinceMiddleGroundSpawn > 4.0f)
        {
            DecorationSpawn();
        }
        
        timeSinceMiddleGroundSpawn += Time.deltaTime;
        timeSinceDecorativeSpawn += Time.deltaTime;

    }

    void DecorationSpawn()
    {
        if (timeSinceDecorativeSpawn >= timeBetweenDecorativeSpawn)
        {
            indexToSpawn = Random.Range(0, decorativeObjects.Length - 1);

            GameObject decoration = Instantiate(decorativeObjects[indexToSpawn]);

            if(decoration.CompareTag("Cat"))
            {
                decoration.transform.position = standingDecorationSpawnPoint.position;
            }
            else if(decoration.CompareTag("Graffiti"))
            {
                decoration.transform.position = thrownObstaclesSpawnPoint.position;
            }
            else
            {
                decoration.transform.position = standingDecorationSpawnPoint.position;
            }

            timeSinceDecorativeSpawn = 0;
            timeBetweenDecorativeSpawn = Random.Range(0.0f, 4.0f);
        }
    }

    void ObstacleSpawn()
    {
        if (timeSinceObstacleSpawn >= timeBetweenObstacleSpawn)
        {
            indexToSpawn = Random.Range(0, obstacles.Length - 1);

            GameObject obstacle = Instantiate(obstacles[indexToSpawn]);

            if(obstacle.CompareTag("Puddles"))
            {
                obstacle.transform.position = groundedObstaclesSpawnPoint.position;
            }
            else
            {
                obstacle.transform.position = thrownObstaclesSpawnPoint.position;
            }

            timeBetweenObstacleSpawn = 1.3f + Random.Range(-0.9f, +1.0f);

            timeSinceObstacleSpawn = 0f;
        }
        else
        {
            timeSinceObstacleSpawn += Time.deltaTime;
        }
    }
}