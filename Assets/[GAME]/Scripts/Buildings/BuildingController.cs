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
    public SpriteRenderer[] occupiedCellSprRend;
    public Color color1, color2, color3;

    // ==================================================================

    public BuildingsSO buildingData;

    public List<GameObject> neighbourGridCells;

    [SerializeField] GameObject floatingNumber;
 
    // ==================================================================

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
        occupiedCellSprRend = GetComponentsInChildren<SpriteRenderer>();

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


    public void ChangeLayer(string newLayer)
    {
        int newLayerIndex = LayerMask.NameToLayer(newLayer);

        gameObject.layer = newLayerIndex;
    }

    // ==================================================================

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;

        for (int i = 0; i < occupiedCellSprRend.Length; i++)
        {
            occupiedCellSprRend[i].color = color;
        }
    }

    // ==================================================================

    public void StartGeneratingResources()
    {
        StartCoroutine(GenerateResources());
    }

    public IEnumerator GenerateResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(buildingData.generationTimer);

            GameManager.Instance.AddGold(buildingData.generatedGold);
            GameManager.Instance.AddGems(buildingData.generatedGem);

            GameObject floatingNumberGold = Instantiate(floatingNumber, transform.position, Quaternion.identity);
            floatingNumberGold.GetComponent<FloatingNumber>().SetText(buildingData.generatedGold.ToString());

            GameObject floatingNumberGem = Instantiate(floatingNumber, transform.position + Vector3.right, Quaternion.identity);
            floatingNumberGem.GetComponent<FloatingNumber>().SetText(buildingData.generatedGem.ToString());
        }
    }

    // ==================================================================

    public void ChangeState(BuildingBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    // ==================================================================

}
