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

        if (Input.GetMouseButtonDown(0) && PlayerInputController.Instance.RaycastToGetGridcell() != null)
        {
            if (!PlayerInputController.Instance.RaycastToGetGridcell().GetComponent<CellScript>().isOccupied)
            {
                GameObject gridCell = PlayerInputController.Instance.RaycastToGetGridcell();
                building.transform.position = gridCell.transform.position;
                building.ChangeState(building.DroppedState);

                gridCell.GetComponent<CellScript>().isOccupied = true;
            }
        }

    }
}
