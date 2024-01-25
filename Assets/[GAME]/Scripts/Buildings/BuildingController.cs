using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image fillBarImage;


    float timeElapsed = 0f;
    float fillAmount = 0f;


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

    // ==================================================================

    private IEnumerator GenerateResources()
    {

        while (true)
        {
            yield return null; // Wait for the next frame

            timeElapsed += Time.deltaTime;

            // Update fill bar based on time elapsed
            fillAmount = timeElapsed / buildingData.generationTimer;
            fillBarImage.fillAmount = fillAmount;

            if (timeElapsed >= buildingData.generationTimer)
            {
                GameManager.Instance.AddGold(buildingData.generatedGold);
                GameManager.Instance.AddGems(buildingData.generatedGem);

                GameObject floatingNumberGold = ObjectPoolingManager.Instance.GetPooledObject(floatingNumber);
                floatingNumberGold.GetComponent<FloatingNumber>().SetText(buildingData.generatedGold.ToString());
                floatingNumberGold.transform.position = transform.position;
                floatingNumberGold.SetActive(true);

                GameObject floatingNumberGem = ObjectPoolingManager.Instance.GetPooledObject(floatingNumber);
                floatingNumberGem.GetComponent<FloatingNumber>().SetText(buildingData.generatedGem.ToString());
                floatingNumberGem.transform.position = transform.position + Vector3.right;
                floatingNumberGem.SetActive(true);

                // Reset time elapsed and fill bar
                timeElapsed = 0f;
                fillBarImage.fillAmount = 0f;
                fillAmount = 0f;
            }
        }
    }

    // ==================================================================

    public void ChangeState(BuildingBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    // ==================================================================

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    // ==================================================================

}
