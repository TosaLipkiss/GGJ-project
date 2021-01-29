using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject creditButton;
    public GameObject exitButton;



    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
    }
}
