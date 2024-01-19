using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonScript : MonoBehaviour
{
    [SerializeField] ResourceController rc;
    [SerializeField] UIManager uiMan;

    public void DecreaseAndUpdateGold()
    {
        rc.DeductResources(1,2);
        uiMan.UpdateUI(rc.gold, rc.gem);
    }
}
