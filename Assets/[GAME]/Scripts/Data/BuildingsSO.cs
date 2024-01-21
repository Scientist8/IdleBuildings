using UnityEngine;

[CreateAssetMenu(fileName = "BuildingsData", menuName = "Custom/BuildingsSO")]
public class BuildingsSO : ScriptableObject
{
    public string buildingName;
    public int buildingGoldCost, buildingGemCost;
    public GameObject buildingPrefab;
    public Vector2Int[] occupiedGridCells;

    // XX
    //  XX
    // For the shape above
    // The occupiedGridCells array would be:

    // occupiedGridCells = new Vector2Int[]
    // {
    //     new Vector2Int(0, 0),
    //     new Vector2Int(1, 0),
    //     new Vector2Int(0, 1),
    //     new Vector2Int(-1, 1)
    // };
}