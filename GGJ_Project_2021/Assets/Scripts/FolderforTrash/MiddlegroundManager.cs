using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlegroundManager: MonoBehaviour
{
    public GameObject middleGroundObject;

    //float timeUntilNextSpawn;
    //float timeSinceLastSpawn;
    //public float minimumTimeUntilSpawn = 25;
    //public float maximumTimeUntilSpawn = 40;

    void Start()
    {
        //Vector2 positionMiddleGroundObject = transform.position;

        //timeSinceLastSpawn = 0;

        //timeUntilNextSpawn = Random.Range(minimumTimeUntilSpawn, maximumTimeUntilSpawn);
    }

    //void update()
    //{
    //    if (timesincelastspawn >= timeuntilnextspawn)
    //    {
    //        instantiate(middlegroundobject, transform.position, quaternion.identity);

    //        timesincelastspawn = 0;
    //        timeuntilnextspawn = random.range(minimumtimeuntilspawn, maximumtimeuntilspawn);
    //    }
    //    else
    //    {
    //        timesincelastspawn += time.deltatime;
    //    }
    //}

    public void Spawn()
    {
        Instantiate(middleGroundObject, transform.position, Quaternion.identity);
    }
}
