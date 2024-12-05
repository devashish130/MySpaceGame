using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("PauseButton");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Resume");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
