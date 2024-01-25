using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingButtonsManager : MonoBehaviour
{
    [SerializeField] BuildingsSO buildingAData, buildingBData, buildingCData, buildingDData, buildingEData, buildingFData;
    [SerializeField] GameObject occupiedCellPrefab;
    [SerializeField] GameObject floatingNumber;
    [SerializeField] Vector3 goldTextPos, gemTextPos;

    // =====================================================================

    public void BuyBuildingA()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingAData.buildingGoldCost, buildingAData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingAData.buildingGoldCost, buildingAData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingAData);

            GetAndDisplayFloatingNumbers(buildingAData);

        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    public void BuyBuildingB()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingBData.buildingGoldCost, buildingBData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingBData.buildingGoldCost, buildingBData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingBData);

            GetAndDisplayFloatingNumbers(buildingBData);

        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    public void BuyBuildingC()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingCData.buildingGoldCost, buildingCData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingCData.buildingGoldCost, buildingCData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingCData);

            GetAndDisplayFloatingNumbers(buildingCData);

        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    public void BuyBuildingD()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingDData.buildingGoldCost, buildingDData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingDData.buildingGoldCost, buildingDData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingDData);

            GetAndDisplayFloatingNumbers(buildingDData);

        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }

    public void BuyBuildingE()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingEData.buildingGoldCost, buildingEData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingEData.buildingGoldCost, buildingEData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingEData);

            GetAndDisplayFloatingNumbers(buildingEData);

        }
        else
        {
            Debug.Log("Not enough resources to build!");
        }
    }


    public void BuyBuildingF()
    {
        // Check if there are enough resources to build
        if (CanAffordBuilding(buildingFData.buildingGoldCost, buildingFData.buildingGemCost))
        {
            // Spend resources
            SpendResources(buildingFData.buildingGoldCost, buildingFData.buildingGemCost);

            GetBuildingAndOccupiedCells(buildingFData);

            GetAndDisplayFloatingNumbers(buildingFData);

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
    }

    private void GetBuildingAndOccupiedCells(BuildingsSO buildingData)
    {
        GameObject building = ObjectPoolingManager.Instance.GetPooledObject(buildingData.buildingPrefab);
        building.SetActive(true);

        for (int i = 0; i < buildingData.occupiedGridCells.Count(); i++)
        {
            GameObject occupiedCell = ObjectPoolingManager.Instance.GetPooledObject(occupiedCellPrefab);
            occupiedCell.SetActive(true);
            occupiedCell.transform.position = building.transform.position + new Vector3(buildingData.occupiedGridCells[i].x, buildingData.occupiedGridCells[i].y, 0);
            occupiedCell.transform.parent = building.transform;
        }
    }

    private void GetAndDisplayFloatingNumbers(BuildingsSO buildingData)
    {
        GameObject floatingNGold = ObjectPoolingManager.Instance.GetPooledObject(floatingNumber);
        floatingNGold.transform.position = goldTextPos;
        floatingNGold.SetActive(true);
        floatingNGold.GetComponent<FloatingNumber>().SetText(buildingData.buildingGoldCost.ToString());

        GameObject floatingNGem = ObjectPoolingManager.Instance.GetPooledObject(floatingNumber);
        floatingNGem.transform.position = gemTextPos;
        floatingNGem.SetActive(true);
        floatingNGem.GetComponent<FloatingNumber>().SetText(buildingData.buildingGemCost.ToString());
    }
}
