using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private bool isPlayerAlive = true; // Variable to track player's life state

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                gameOverPanel.SetActive(true);
                isPlayerAlive = false; // Set player state to dead
                StopGameMovement();
            }
        }
    }

    void StopGameMovement()
    {
        // Put your code here to stop game movement, such as freezing time or disabling player controls.
        // For example:
        Time.timeScale = 0; // This stops the time in the game
        // You may also want to disable player controls, animations, etc.
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // You may need to reset isPlayerAlive to true here if needed
        Time.timeScale = 1; // Ensure time scale is reset to normal
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
        Time.timeScale = 1; // Ensure time scale is reset to normal
    }
}
