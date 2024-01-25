using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingButtonsManager : MonoBehaviour
{
    [SerializeField] BuildingsSO buildingsSO;
    [SerializeField] GameObject occupiedCellPrefab;
    [SerializeField] GameObject floatingNumber;
    [SerializeField] Vector3 goldTextPos, gemTextPos;

    public void GetBuildingA()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingsSO.buildingGoldCost, buildingsSO.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingsSO.buildingGoldCost, buildingsSO.buildingGemCost);

            // TODO: Object pool sounds good
            // Instantiate building
            GameObject building = Instantiate(buildingsSO.buildingPrefab, Vector2.zero, Quaternion.identity);

            for (int i = 0; i < buildingsSO.occupiedGridCells.Count(); i++)
            {
                GameObject occupiedCell = Instantiate(occupiedCellPrefab);
                occupiedCell.transform.position = building.transform.position + new Vector3(buildingsSO.occupiedGridCells[i].x, buildingsSO.occupiedGridCells[i].y, 0);
                occupiedCell.transform.parent = building.transform;
            }

            GameObject floatingNGold = Instantiate(floatingNumber, goldTextPos, Quaternion.identity);
            floatingNGold.GetComponent<FloatingNumber>().SetText(buildingsSO.buildingGoldCost.ToString());

            GameObject floatingNGem = Instantiate(floatingNumber, gemTextPos, Quaternion.identity);
            floatingNGem.GetComponent<FloatingNumber>().SetText(buildingsSO.buildingGemCost.ToString());


        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    private bool CanAffordBuilding(int goldCost, int gemCost)
    {
        // Return true if resources are enough, false otherwise
        if (goldCost <= GameManager.Instance.gold && gemCost <= GameManager.Instance.gems)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpendResources(int goldCost, int gemCost)
    {
        GameManager.Instance.SubtractGold(goldCost);
        GameManager.Instance.SubtractGems(gemCost);
        // I want to have a resource manager or some global script to handle this
        // Debug.Log("Resources spent: " + cost);
    }
}
