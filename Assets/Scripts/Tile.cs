using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Represents a single Minesweeper tile
[RequireComponent(typeof(Button), typeof(Image))]
public class Tile : MonoBehaviour
{
    // --- UI Colors ---
    private Color32 hiddenColor = new Color32(148, 163, 184, 255);
    private Color32 revealedColor = new Color32(226, 232, 240, 255);
    private Color32 bombColor = new Color32(232, 76, 76, 255);

    // --- Tile state ---
    public bool isBomb = false;
    public bool isRevealed = false;
    public bool isNumbered = false;
    public int adjacentBombs = 0;

    // --- UI references ---
    private Button button;
    private TextMeshProUGUI text;
    private Image img;

    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        img = GetComponent<Image>();

        // Start hidden
        img.color = hiddenColor;
        text.text = "";
        button.interactable = true;

        // Button hover/press colors
        button.transition = Selectable.Transition.ColorTint;
        ColorBlock cb = button.colors;
        cb.normalColor = hiddenColor;
        cb.highlightedColor = new Color32(168, 182, 201, 255);
        cb.pressedColor = new Color32(203, 213, 225, 255);
        cb.disabledColor = revealedColor;
        button.colors = cb;
    }

    // Reveal tile (UPDATED)
    public void Reveal(bool playSound = true)
    {
        if (isRevealed) return;

        isRevealed = true;
        button.interactable = false;

        if (isBomb)
        {
            img.color = bombColor;
            text.text = "";
        }
        else
        {
            // Play sound ONLY once (first tile)
            if (playSound)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.revealSound);
            }

            img.color = revealedColor;
            text.text = adjacentBombs > 0 ? adjacentBombs.ToString() : "";
            isNumbered = adjacentBombs > 0;

            // Number colors
            switch (adjacentBombs)
            {
                case 1: text.color = new Color32(59, 130, 246, 255); break;
                case 2: text.color = new Color32(34, 197, 94, 255); break;
                case 3: text.color = new Color32(239, 68, 68, 255); break;
                case 4: text.color = new Color32(29, 78, 216, 255); break;
                case 5: text.color = new Color32(185, 28, 28, 255); break;
                case 6: text.color = new Color32(8, 145, 178, 255); break;
                case 7: text.color = new Color32(17, 24, 39, 255); break;
                case 8: text.color = new Color32(107, 114, 128, 255); break;
                default: text.color = Color.black; break;
            }

            // If empty tile → reveal neighbors WITHOUT sound
            if (adjacentBombs == 0)
            {
                foreach (Tile neighbor in FindNeighbors()) // or your own neighbor list
                {
                    neighbor.Reveal(false); // ❌ no sound spam
                }
            }
        }
    }

    // Replace this with your actual neighbor logic if you have one
    private Tile[] FindNeighbors()
    {
        return new Tile[0];
    }

    // Reset tile (useful when restarting game)
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