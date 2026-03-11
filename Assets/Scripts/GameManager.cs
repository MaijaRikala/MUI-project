using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Make GameManager static, so other classes can reference it
    public static GameManager Instance { get; private set; }

    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject mainMenuPanel;
    public GameObject victoryPanel;
    public GameObject losePanel;

    // If a script will be using the singleton in its awake method, make sure the manager is first to
    // execute with the Script Execution Order project settings
    void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
    }

    // Handle destroying GameManager
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

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

    public void WinGame()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
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