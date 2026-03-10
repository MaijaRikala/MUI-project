using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Represents a single Minesweeper tile.
[RequireComponent(typeof(Button), typeof(Image))]
public class Tile : MonoBehaviour
{
    // --- UI Colors ---
    private Color32 hiddenColor = new Color32(148, 163, 184, 255);   // #94A3B8
    private Color32 revealedColor = new Color32(226, 232, 240, 255); // #E2E8F0
    private Color32 bombColor = new Color32(239, 68, 68, 255);       // #EF4444

    // --- Tile state ---
    public bool isBomb = false;
    public bool isRevealed = false;
    public int adjacentBombs = 0;

    // --- Cached UI components ---
    private Button button;
    private TextMeshProUGUI text;
    private Image img;

    void Awake()
    {
        // Cache references
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        img = GetComponent<Image>();

        // Initialize as hidden
        img.color = hiddenColor;
        text.text = "";
        button.interactable = true;

        // Optional: Make button tint match hover/pressed effect
        button.transition = Selectable.Transition.ColorTint;
        ColorBlock cb = button.colors;
        cb.normalColor = hiddenColor;
        cb.highlightedColor = new Color32(168, 182, 201, 255); // hover
        cb.pressedColor = new Color32(203, 213, 225, 255);     // pressed
        cb.disabledColor = revealedColor;                      // disabled (revealed)
        button.colors = cb;
    }

    // Reveal tile
    public void Reveal()
    {
        if (isRevealed) return;

        isRevealed = true;
        button.interactable = false;

        if (isBomb)
        {
            text.text = "B";          
            text.color = Color.white;   // contrast
            img.color = bombColor;
        }
        else
        {
            text.text = adjacentBombs > 0 ? adjacentBombs.ToString() : "";
            img.color = revealedColor;

            // Number colors
            switch (adjacentBombs)
            {
                case 1: text.color = new Color32(59, 130, 246, 255); break;   // blue
                case 2: text.color = new Color32(34, 197, 94, 255); break;    // green
                case 3: text.color = new Color32(239, 68, 68, 255); break;    // red
                case 4: text.color = new Color32(29, 78, 216, 255); break;    // dark blue
                case 5: text.color = new Color32(185, 28, 28, 255); break;    // dark red
                case 6: text.color = new Color32(8, 145, 178, 255); break;    // teal
                case 7: text.color = new Color32(17, 24, 39, 255); break;     // black
                case 8: text.color = new Color32(107, 114, 128, 255); break;  // gray
                default: text.color = Color.black; break;
            }
        }
    }

    // Optional: Reset tile (useful if restarting)
    public void ResetTile()
    {
        isBomb = false;
        isRevealed = false;
        adjacentBombs = 0;
        text.text = "";
        img.color = hiddenColor;
        button.interactable = true;
    }
}