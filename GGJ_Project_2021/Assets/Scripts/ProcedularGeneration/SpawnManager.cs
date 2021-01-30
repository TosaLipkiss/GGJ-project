using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public TimeScript timeScript;
    public Transform pickUpSpawnPoint;

    public Transform groundedObstaclesSpawnPoint;
    public Transform thrownObstaclesSpawnPoint;

    public Transform standingDecorationSpawnPoint;

    GameObject landfillObjects;
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
    float pickUpSpawnInterval;

    int indexToSpawn;
    public bool introVictory = false;
    public bool victory = false;


    void Start()
    {
        landfillObjects = Resources.Load<GameObject>("Prefabs/Landfill/Middleground_Landfill");
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
        LandfillSpawn();
        if (victory == false)
        {
            SpawnPickUp();
            MiddleGroundSpawn();
            ObstacleSpawn();
        }
    }

    void SpawnPickUp()
    {
        if(timeScript.currentTime > 50f)
        {
            pickUpSpawnInterval = Random.Range(1f, 4f);
        }
        else
        {
            pickUpSpawnInterval = Random.Range(0.5f, 2f);
        }
        if (pickUpSpawnTimer >= pickUpSpawnInterval && timeScript.currentTime > 5f)
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

    void LandfillSpawn()
    {
        if (timeScript.currentTime <= 11f && introVictory == false)
        {
            victory = true;
            introVictory = true;
            Instantiate(landfillObjects, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        }
    }

    void MiddleGroundSpawn()
    {
        if (timeSinceMiddleGroundSpawn >= timeBetweenMiddleGroundSpawn && timeScript.currentTime > 5f)
        {
            indexToSpawn = Random.Range(0, middleGroundObjects.Length);

            Instantiate(middleGroundObjects[indexToSpawn], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);

            timeBetweenMiddleGroundSpawn = 6 + Random.Range(-3f, +3f);
            timeSinceMiddleGroundSpawn = 0f;
        }
        else if(timeSinceMiddleGroundSpawn > 4.0f)
        {
           // DecorationSpawn();
        }
        
        timeSinceMiddleGroundSpawn += Time.deltaTime;
        timeSinceDecorativeSpawn += Time.deltaTime;

    }

    void DecorationSpawn()
    {
        if (timeSinceDecorativeSpawn >= timeBetweenDecorativeSpawn)
        {
            indexToSpawn = Random.Range(0, decorativeObjects.Length);

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
        if (timeSinceObstacleSpawn >= timeBetweenObstacleSpawn && timeScript.currentTime > 5f)
        {
            indexToSpawn = Random.Range(0, obstacles.Length);

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