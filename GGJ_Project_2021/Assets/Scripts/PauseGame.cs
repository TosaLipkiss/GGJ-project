﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseText;
    public bool pause = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                pause = true;
                pauseText.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pause = false;
                pauseText.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
