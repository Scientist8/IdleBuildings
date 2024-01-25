using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDraggingState : BuildingBaseState
{
    public override void EnterState(BuildingController building)
    {
        building.ChangeColor(building.color1);
        building.ChangeLayer("Ignore Raycast");
    }

    public override void UpdateState(BuildingController building)
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        building.transform.position = worldMousePosition;

        GameObject gridCell = PlayerInputController.Instance.RaycastToGetGridcell();

        // Check if the building is placeable
        bool isPlaceable = CheckIfPlaceable(building, gridCell);

        // Change color based on whether it's placeable or not
        building.ChangeColor(isPlaceable ? building.color1 : building.color2);

        if (Input.GetMouseButtonDown(0))
        {
            if (gridCell != null && !gridCell.GetComponent<CellScript>().isOccupied && isPlaceable)
            {
                for (int i = 0; i < building.buildingData.occupiedGridCells.Length; i++)
                {
                    Vector2Int offset = building.buildingData.occupiedGridCells[i];
                    CellScript neighbourGridCell = PlayerInputController.Instance.GetNeighbourGridCell(gridCell, offset)?.GetComponent<CellScript>();

                    if (neighbourGridCell == null || neighbourGridCell.isOccupied)
                    {
                        // Don't set isOccupied or add to the list, just return
                        return;
                    }
                }

                // If we reach here, none of the conditions were met, proceed with setting isOccupied and adding to the list
                gridCell.GetComponent<CellScript>().isOccupied = true;

                for (int i = 0; i < building.buildingData.occupiedGridCells.Length; i++)
                {
                    Vector2Int offset = building.buildingData.occupiedGridCells[i];
                    CellScript neighbourGridCell = PlayerInputController.Instance.GetNeighbourGridCell(gridCell, offset)?.GetComponent<CellScript>();

                    neighbourGridCell.isOccupied = true;
                    building.neighbourGridCells.Add(neighbourGridCell.gameObject);
                }

                building.transform.position = gridCell.transform.position;
                building.ChangeState(building.DroppedState);
            }

            else
            {
                GameManager.Instance.AddGold(building.buildingData.buildingGoldCost);
                GameManager.Instance.AddGems(building.buildingData.buildingGemCost);

                building.DeactivateObject();
            }
        }
    }

    private bool CheckIfPlaceable(BuildingController building, GameObject gridCell)
    {
        for (int i = 0; i < building.buildingData.occupiedGridCells.Length; i++)
        {
            Vector2Int offset = building.buildingData.occupiedGridCells[i];
            CellScript neighbourGridCell = PlayerInputController.Instance.GetNeighbourGridCell(gridCell, offset)?.GetComponent<CellScript>();

            if (neighbourGridCell == null || neighbourGridCell.isOccupied)
            {
                return false;
            }
        }
        return true;
    }
}
