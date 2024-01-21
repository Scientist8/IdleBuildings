using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    // States
    public BuildingBaseState CurrentState;
    public BuildingDraggingState DraggingState;
    public BuildingDroppedState DroppedState;

    // ==================================================================

    public SpriteRenderer spriteRenderer;
    public Color color1, color2;

    // ==================================================================

    public BuildingsSO buildingData;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize states
        DraggingState = new BuildingDraggingState();
        DroppedState = new BuildingDroppedState();
    }

    // ==================================================================

    void Start()
    {
        // Go into the first state
        CurrentState = DraggingState;
        CurrentState.EnterState(this);

    }

    // ==================================================================

    void Update()
    {
        // Call update function for current state
        CurrentState.UpdateState(this);
    }

    // ==================================================================


    // ==================================================================

    public void ChangeLayer(string newLayer)
    {
        int newLayerIndex = LayerMask.NameToLayer(newLayer);

        gameObject.layer = newLayerIndex;
    }

    // ==================================================================

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    // ==================================================================

    public void ChangeState(BuildingBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    // ==================================================================

}
