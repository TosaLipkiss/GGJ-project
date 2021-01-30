using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 120.0f;
    public float currentTime;

    void Start()
    {
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
            Time.timeScale = 0;
        }

        if(currentTime < 115)
        {
            Debug.Log("Time is under 115");
            GameManager.constantMovement = 4f;
        }
        if (currentTime < 110)
        {
            Debug.Log("Time is under 110");
            GameManager.constantMovement = 5f;
        }
    }
}
