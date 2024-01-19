using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    
    public int gold = 10;
    public int gem = 10;

    public void DeductResources(int goldAmount, int gemAmount)
    {
        gold -= goldAmount;
        gem -= gemAmount;
    }
    
}
