using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public GameObject pickupObject;

    float timeUntilNextPickupSpawn;
    float timeSinceLastPickUpSpawn;
    public float minimumTimeUntilPickupSpawn = 10;
    public float maximumTimeUntilPickupSpawn = 15;

    void Start()
    {
        Vector2 positionPickup = transform.position;

        timeSinceLastPickUpSpawn = 0;

        timeUntilNextPickupSpawn = Random.Range(minimumTimeUntilPickupSpawn, maximumTimeUntilPickupSpawn);
    }

    void Update()
    {
        if (timeSinceLastPickUpSpawn >= timeUntilNextPickupSpawn)
        {
            Instantiate(pickupObject, transform.position, Quaternion.identity);

            timeSinceLastPickUpSpawn = 0;
            timeUntilNextPickupSpawn = Random.Range(minimumTimeUntilPickupSpawn, maximumTimeUntilPickupSpawn);
        }
        else
        {
            timeSinceLastPickUpSpawn += Time.deltaTime;
        }
    }
}
