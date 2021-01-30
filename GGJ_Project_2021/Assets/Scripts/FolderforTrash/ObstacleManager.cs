using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
        public GameObject obstacle;

        float timeUntilNextObstacleSpawn;
        float timeSinceLastObstacleSpawn;
        public float minimumTimeUntilObstacleSpawn = 6;
        public float maximumTimeUntilObstacleSpawn = 10;

        void Start()
        {
            Vector2 positionObstacle = transform.position;

            timeSinceLastObstacleSpawn = 0;

            timeUntilNextObstacleSpawn = Random.Range(minimumTimeUntilObstacleSpawn, maximumTimeUntilObstacleSpawn);
        }

        void Update()
        {
            if (timeSinceLastObstacleSpawn >= timeUntilNextObstacleSpawn)
            {
                Instantiate(obstacle, transform.position, Quaternion.identity);

                timeSinceLastObstacleSpawn = 0;
                timeUntilNextObstacleSpawn = Random.Range(minimumTimeUntilObstacleSpawn, maximumTimeUntilObstacleSpawn);
            }
            else
            {
                timeSinceLastObstacleSpawn += Time.deltaTime;
            }
        }
}
