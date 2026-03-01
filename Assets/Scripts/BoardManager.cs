using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public GameObject tilePrefab; // drag Tile prefab here
    public int width = 8;
    public int height = 8;

    private GameObject[,] tiles;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        tiles = new GameObject[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                tile.name = $"Tile {x},{y}";
                tiles[x, y] = tile;
            }
        }
    }
}