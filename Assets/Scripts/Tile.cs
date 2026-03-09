using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Represents a single tile on the Minesweeper-style board.
// Responsible for storing tile state (bomb, revealed, adjacent bomb count)
// and updating its visual presentation when revealed.
public class Tile : MonoBehaviour
{
    // Public state used by BoardManager and game logic:
    public bool isBomb = false;        // true if this tile contains a bomb
    public bool isRevealed = false;    // true once the tile has been revealed
    public int adjacentBombs = 0;      // number of bombs in the 8-neighborhood

    // Cached UI components for quick access
    private Button button;
    private TextMeshProUGUI text;

    // Awake: cache references to required components.
    // Assumes the tile prefab has a Button on the same GameObject and
    // a TextMeshProUGUI child used to display numbers / "bomb".
    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Reveal this tile's contents and update its visuals.
    // - If already revealed, does nothing.
    // - Disables the button to prevent further clicks.
    // - If it's a bomb: shows "bomb", colors text red and sets a subtle bomb background.
    // - If not a bomb: shows adjacent bomb count (or empty string for zero) and sets white background.
    public void Reveal()
    {
        if (isRevealed) return;

        isRevealed = true;
        button.interactable = false;

        if (isBomb)
        {
            // Display bomb and visual cue for explosion
            text.text = "bomb";
            text.color = Color.red;

            // Soft red/pink background to indicate bomb tile.
            GetComponent<Image>().color = new Color32(254, 202, 202, 255);
        }
        else
        {
            // Show adjacent bomb count if > 0, otherwise show nothing.
            text.text = adjacentBombs > 0 ? adjacentBombs.ToString() : "";

            // Neutral background for revealed safe tile.
            GetComponent<Image>().color = Color.white;
        }
    }
}