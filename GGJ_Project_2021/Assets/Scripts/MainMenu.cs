using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public AudioClip guiButtons;
    public AudioSource audioSource;
    public GameObject creditScreen;
    public GameObject playButton;
    public GameObject creditButton;
    public GameObject exitButton;
    public GameObject backButton;



    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    public void OpenCreditButton()
    {
        audioSource.clip = guiButtons;
        audioSource.Play();
        creditScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void CloseCreditButton()
    {
        audioSource.clip = guiButtons;
        audioSource.Play();
        creditScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(creditButton);
    }
}
