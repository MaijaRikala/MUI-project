using System;
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

    // All possible Gamestates
    public enum GameState
    {
        Play,
        Options,
        Victory,
        Lose
        // and something for the main menu?
    }

    // Variable for the current gamestate
    public GameState State;



    // Initialize ----------------------------------------------------

    // Initialize variables, in this case only _instance
    // Set _instance reference as soon as possible
    private void Awake() {
        _instance = this;
    }


    // State control -------------------------------------------------

    // Control gamestate changes
    public void UpdateGameState(GameState newState)
    {
        // Set current state
        State = newState;

        // Check current state and handle accordingly
        switch (newState)
        {
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Options:
                HandleOptions();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    private void HandlePlay()
    {
        //tähän ehkä SceneManager.LoadScene() ja tonne scenen nimi/indeksi
    }

    private void HandleOptions()
    {
        //tähän ehkä SceneManager.LoadScene() ja tonne scenen nimi/indeksi
    }

    private void HandleLose()
    {
        //tähän ehkä SceneManager.LoadScene() ja tonne scenen nimi/indeksi
    }

    private void HandleVictory()
    {
        //tähän ehkä SceneManager.LoadScene() ja tonne scenen nimi/indeksi
    }



    // Scene control -------------------------------------------------

    // Simple restart function for the scene
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    // Quit game -----------------------------------------------------

    public void QuitGame() => Application.Quit();

}
