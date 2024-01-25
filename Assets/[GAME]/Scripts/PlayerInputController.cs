using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController Instance { get; private set; }

    // =========================================================================

    void Awake()
    {
        SingletonThisObject();
    }

    // =========================================================================

    void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // =========================================================================

    void Update()
    {

    }

    public GameObject RaycastToGetGridcell()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Output the mouse position
        Debug.Log("Mouse Clicked at: " + worldMousePosition);

        // Shoot a ray from the mouse position into the scene
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Use RaycastHit2D to store the result of the raycast
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            // Debug.Log("Ray hit: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("GridCell"))
            {
                // Debug.Log("GridCell hit!");

                return hit.collider.gameObject;
            }
        }
        else
        {
            return null;
        }

        return null;
    }

    public GameObject GetNeighbourGridCell(GameObject originCell, Vector2Int offset)
    {
        if (originCell == null) return null;

        Vector2 originalPosition = originCell.transform.position;
        Vector2 newPosition = originalPosition + offset;

        Collider2D collider = Physics2D.OverlapPoint(newPosition);

        if (collider != null)
        {
            return collider.gameObject;
        }

        return null;
    }
}
