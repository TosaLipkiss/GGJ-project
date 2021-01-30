using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Player player;
    Image timerBar;
    public float maxTime = 120.0f;
    public float currentTime;

    void Start()
    {
        PhysicsManager.constantMovement = 3f;
        timerBar = GetComponent<Image>();
        currentTime = maxTime;
    }

    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerBar.fillAmount = currentTime / maxTime;
        }
        else
        {
           // Time.timeScale = 0;
        }

        if (currentTime < 5f)
        {
            PhysicsManager.constantMovement = 0f;
        }
        else if (currentTime < 50)
        {
            PhysicsManager.constantMovement = 6f;
        }
        else if (currentTime < 75f)
        {
            PhysicsManager.constantMovement = 5f;
        }
        else if (currentTime < 100f)
        {
            PhysicsManager.constantMovement = 4f;
        }
    }
}
