using UnityEngine;
using UnityEngine.UI;       
using TMPro;               

// Manages the Minesweeper-style board: creating tiles, placing bombs, computing
// adjacent bomb counts and handling tile clicks.
public class BoardManager : MonoBehaviour
{
    // Prefab for each tile. Expected to have a `Tile` component and a `Button`.
    public GameObject tilePrefab;

    // Board dimensions (columns x rows)
    public int width = 8;
    public int height = 8;

    // Number of bombs to place on the board
    public int bombCount = 10;

    // Internal 2D array holding Tile references for quick access
    private Tile[,] tiles;

    // Unity start: generate board and initialize game data
    void Start()
    {
        GenerateBoard();
        PlaceBombs();
        CalculateNumbers();
    }

    // Instantiate tile prefabs and populate the tiles array.
    // Also wires up Button.onClick listeners for each tile.
    void GenerateBoard()
    {
        tiles = new Tile[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Create a tile as a child of this manager (for scene hierarchy)
                GameObject obj = Instantiate(tilePrefab, transform);

                // Cache the Tile component for game logic interaction
                Tile tile = obj.GetComponent<Tile>();
                tiles[x, y] = tile;

                // Capture loop indices in local variables to avoid closure issues
                // when adding the lambda listener (otherwise all listeners would
                // use the final loop values).
                int cx = x;
                int cy = y;

                // Expect the prefab to have a Button component; clicking it calls OnTileClicked.
                obj.GetComponent<Button>().onClick.AddListener(() => OnTileClicked(cx, cy));
            }
        }
    }

    // Randomly place bombs until the desired bombCount is reached.
    // Ensures we don't place more than one bomb per tile.
    void PlaceBombs()
    {
        int bombsPlaced = 0;

        while (bombsPlaced < bombCount)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            if (!tiles[x, y].isBomb)
            {
                tiles[x, y].isBomb = true;
                bombsPlaced++;
            }
        }
    }

    // For every non-bomb tile, count adjacent bombs (8-neighborhood) and store it.
    void CalculateNumbers()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Skip bombs
                if (tiles[x, y].isBomb) continue;

                int count = 0;

                // Check all neighbors (including diagonals)
                for (int ny = -1; ny <= 1; ny++)
                {
                    for (int nx = -1; nx <= 1; nx++)
                    {
                        int checkX = x + nx;
                        int checkY = y + ny;

                        // Bounds check
                        if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                        {
                            if (tiles[checkX, checkY].isBomb)
                                count++;
                        }
                    }
                }

                tiles[x, y].adjacentBombs = count;
            }
        }
    }

    // Called when a tile is clicked.
    // Reveals the tile, handles bombs (game over) and empty-tile expansion.
    void OnTileClicked(int x, int y)
    {
        Tile tile = tiles[x, y];
        tile.Reveal();

        if (tile.isBomb)
        {
            Debug.Log("GAME OVER");
            // Example integration point: notify GameManager of loss:
            // GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
        }
        else if (tile.adjacentBombs == 0)
        {
            // If this tile has no adjacent bombs, reveal its adjacent empty tiles.
            // Note: Current implementation reveals only immediate neighbors.
            // For full flood-fill behavior, consider recursive or queue-based expansion
            // to reveal connected empty areas and their bordering numbered tiles.
            RevealAdjacentEmptyTiles(x, y);
        }

        // TODO: Check win condition (e.g., all non-bomb tiles revealed)
    }

    // Reveal immediate neighboring tiles that are not bombs and not already revealed.
    // This method currently reveals neighbors only one step away.
    void RevealAdjacentEmptyTiles(int x, int y)
    {
        for (int ny = -1; ny <= 1; ny++)
        {
            for (int nx = -1; nx <= 1; nx++)
            {
                int checkX = x + nx;
                int checkY = y + ny;

                // Bounds check
                if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                {
                    Tile t = tiles[checkX, checkY];

                    // Only reveal tiles that haven't been revealed and are not bombs.
                    if (!t.isRevealed && !t.isBomb)
                        t.Reveal();
                }
            }
        }
    }
}