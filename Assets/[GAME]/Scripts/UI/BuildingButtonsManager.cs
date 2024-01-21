using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingButtonsManager : MonoBehaviour
{
    [SerializeField] BuildingsSO buildingsSO;
    [SerializeField] GameObject occupiedCellPrefab;

    public void GetBuildingA()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingsSO.buildingGoldCost, buildingsSO.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingsSO.buildingGoldCost, buildingsSO.buildingGemCost);

            //TODO: I WAS HERE
            
            // Instantiate building
            GameObject building = Instantiate(buildingsSO.buildingPrefab, Vector2.zero, Quaternion.identity);

            for (int i = 0; i < buildingsSO.occupiedGridCells.Count(); i++)
            {
                GameObject occupiedCell = Instantiate(occupiedCellPrefab);
                occupiedCell.transform.position = building.transform.position + new Vector3(buildingsSO.occupiedGridCells[i].x, buildingsSO.occupiedGridCells[i].y, 0);
                occupiedCell.transform.parent = building.transform;
            }
        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    private bool CanAffordBuilding(int goldCost, int gemCost)
    {
        // Return true if resources are enough, false otherwise
        return true; 
    }

    private void SpendResources(int goldCost, int gemCost)
    {
        // I want to have a resource manager or some global script to handle this
        // Debug.Log("Resources spent: " + cost);
    }
}
