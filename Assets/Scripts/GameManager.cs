using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject mainMenuPanel;

    // --- Load Game scene ---
    public void StartGame()
    {
        Time.timeScale = 1f;
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

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    // --- Resume the game ---
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // --- Open Options panel ---
    public void OpenOptions()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    // --- Close Options panel ---
    public void CloseOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
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
        // ESC pauses or resumes the game
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel != null)
        {
            if (pausePanel.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }
    }
}