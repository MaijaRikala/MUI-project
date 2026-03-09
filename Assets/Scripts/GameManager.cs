using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;

    // --- Load Game scene ---
    public void StartGame()
    {
        Time.timeScale = 1f; // Make sure time is normal
        SceneManager.LoadScene("GameMode");
    }

    // --- Quit the application ---
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit pressed");
    }

    // --- Pause the game ---
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    // --- Resume the game ---
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    // --- Restart the current scene ---
    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // --- Go back to Main Menu ---
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        // Press ESC to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }
    }
}