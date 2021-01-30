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

        if (currentTime < 5f)
        {
            GameManager.constantMovement = 0f;
        }
        else if (currentTime < 50)
        {
            GameManager.constantMovement = 6f;
        }
        else if (currentTime < 75f)
        {
            GameManager.constantMovement = 5f;
        }
        else if (currentTime < 100f)
        {
            GameManager.constantMovement = 4f;
        }
    }
}
