using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlegroundManager: MonoBehaviour
{
    public GameObject middleGroundObject;

    float timeUntilNextSpawn;
    float timeSinceLastSpawn;
    float minimumTimeUntilSpawn = 8;
    float maximumTimeUntilSpawn = 16;

    void Start()
    {
        Vector2 positionMiddleGroundObject = transform.position;

        timeSinceLastSpawn = 0;

        timeUntilNextSpawn = Random.Range(minimumTimeUntilSpawn, maximumTimeUntilSpawn);
    }

    void Update()
    {
        if (timeSinceLastSpawn >= timeUntilNextSpawn)
        {
            Instantiate(middleGroundObject, transform.position, Quaternion.identity);

            timeSinceLastSpawn = 0;
            timeUntilNextSpawn = Random.Range(minimumTimeUntilSpawn, maximumTimeUntilSpawn);
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
    }
}
