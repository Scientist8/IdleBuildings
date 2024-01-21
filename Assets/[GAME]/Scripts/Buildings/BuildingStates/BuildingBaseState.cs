using UnityEngine;

public abstract class BuildingBaseState
{
    public abstract void EnterState(BuildingController building);
    public abstract void UpdateState(BuildingController building);
}