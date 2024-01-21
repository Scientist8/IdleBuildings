using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementManager : MonoBehaviour
{
    public static BuildingPlacementManager Instance { get; private set; }

    public List<Vector2Int> occupiedCells = new List<Vector2Int>();

    void Awake()
    {
        Instance = this;
    }

    public bool CanPlaceBuilding(Vector2Int[] occupiedGridCells)
    {
        foreach (var cell in occupiedGridCells)
        {
            Vector2Int targetCell = GetTargetCell(cell);

            // Check if the target cell is already occupied
            if (occupiedCells.Contains(targetCell))
            {
                return false;
            }
        }

        return true;
    }

    public void PlaceBuilding(Vector2Int[] occupiedGridCells)
    {
        foreach (var cell in occupiedGridCells)
        {
            Vector2Int targetCell = GetTargetCell(cell);

            // Mark the target cell as occupied
            occupiedCells.Add(targetCell);
        }
    }

    private Vector2Int GetTargetCell(Vector2Int relativeCell)
    {
        // Assuming each cell size is 1
        return new Vector2Int(relativeCell.x, relativeCell.y);
    }
}
