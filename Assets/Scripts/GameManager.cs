using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Make GameManager static, so other classes can reference it
    public static GameManager Instance { get; private set; }

    [Header("UI Panels")]
    public GameObject pausePanel;
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