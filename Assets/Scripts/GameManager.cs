using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Class variables -----------------------------------------------

    // Static private variable to hold the reference
    private static GameManager _instance;
    // Public reference for other classes (only get, not set)
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("ERROR: no GameManager exists");
            return _instance;
        }
    }



    // Initialize ----------------------------------------------------

    // Initialize variables, in this case only _instance
    // Set _instance reference as soon as possible
    private void Awake() => _instance = this;



    // Scene control -------------------------------------------------

    // Simple restart function for the scene
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    // Quit game -----------------------------------------------------

    public void QuitGame() => Application.Quit();

}
