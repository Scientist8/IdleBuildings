using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDroppedState : BuildingBaseState
{
    public override void EnterState(BuildingController building)
    {
        building.ChangeColor(building.color3);
        building.ChangeLayer("Default");

        building.StartGeneratingResources();
    }

    public override void UpdateState(BuildingController building)
    {
        
    }
}
