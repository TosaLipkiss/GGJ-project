using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtons : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
