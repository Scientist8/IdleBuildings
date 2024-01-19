using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class BuildingCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string buildingName;
    public int buildingCost;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;

    private Vector2 initialPosition;

    void Start()
    {
        nameText.text = buildingName;
        costText.text = "Cost: " + buildingCost;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // if (IsDropValid())
        // {
            
        // }
        // else
        // {
            transform.position = initialPosition;
        // }
    }

    private bool IsDropValid()
    {
        // Implement logic to check if the drop position is valid
        return true;
    }

    public void SetInteractable(bool isInteractable)
    {
        // Enable/disable building card based on player's resources
        // GetComponent<ResourceController>().gold >= buildingCost
        // Set the interactable state of the card accordingly
        GetComponent<Button>().interactable = isInteractable;
    }
}