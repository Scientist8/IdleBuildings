using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public int gridSize = 10;
    public float cellSize = 1.0f;
    private Vector2 spawnPosition;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                spawnPosition = (Vector2.right * x + Vector2.up * y) * cellSize;

                // Round the positions to integers to represent grid coordinates
                int gridX = Mathf.RoundToInt(spawnPosition.x);
                int gridY = Mathf.RoundToInt(spawnPosition.y);

                GameObject cell = Instantiate(cellPrefab, spawnPosition, Quaternion.identity, transform);

                // Attach a script to the cell to store grid coordinates
                CellScript cellScript = cell.AddComponent<CellScript>();
                cellScript.SetGridCoordinates(gridX, gridY);

                cell.name = $"Cell_{gridX}_{gridY}"; // Assign unique name to each cell
            }
        }
    }
}
