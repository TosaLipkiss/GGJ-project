using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtons : MonoBehaviour
{
    public AudioClip guiButtons;
    public AudioSource audioSource;
    public void Restart()
    {
        audioSource.clip = guiButtons;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGameButton()
    {
        audioSource.clip = guiButtons;
        audioSource.Play();
        Application.Quit();
    }

    public void PlayGameButton()
    {
        audioSource.clip = guiButtons;
        audioSource.Play();
        SceneManager.LoadScene("GamePlayScene");
    }

    public void BackToMainMenu()
    {
        audioSource.clip = guiButtons;
        audioSource.Play();
        SceneManager.LoadScene("MainMenuScene");
    }
}
