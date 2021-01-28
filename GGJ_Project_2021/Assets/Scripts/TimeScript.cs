using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 10f;
    public float currentTime;
    public GameObject timesUp;

    void Start()
    {
        timesUp.SetActive(false);
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
            timesUp.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
