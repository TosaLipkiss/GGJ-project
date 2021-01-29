using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtons : MonoBehaviour
{
    public void restart()
    {
        Debug.Log("restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
