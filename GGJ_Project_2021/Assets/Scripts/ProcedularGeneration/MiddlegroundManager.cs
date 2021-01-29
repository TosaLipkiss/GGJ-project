using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlegroundManager: MonoBehaviour
{
    public GameObject middleGroundObject;

    float timeUntilNextSpawn;
    float timeSinceLastSpawn;
    public float minimumTimeUntilSpawn = 25;
    public float maximumTimeUntilSpawn = 40;

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
