using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinandLose : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
