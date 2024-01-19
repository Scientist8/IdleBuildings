using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text gemText;

    public void UpdateUI(int gold, int gem)
    {
        goldText.text = "Gold: " + gold;
        gemText.text = "Gem: " + gem;
    }
}
