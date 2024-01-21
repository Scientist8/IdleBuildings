using UnityEngine;

public class CellScript : MonoBehaviour
{
    private int gridX;
    private int gridY;

    public bool isOccupied = false;

    public void SetGridCoordinates(int x, int y)
    {
        gridX = x;
        gridY = y;
    }

    public Vector2 GetGridCoordinates()
    {
        return new Vector2(gridX, gridY);
    }
}
