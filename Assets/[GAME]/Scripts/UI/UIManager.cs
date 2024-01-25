using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] BuildingsSO buildingAData, buildingBData, buildingCData, buildingDData, buildingEData, buildingFData;
    [SerializeField] TMP_Text goldText, gemText;
    [SerializeField] TMP_Text buildingANameText, buildingBNameText, buildingCNameText, buildingDNameText, buildingENameText, buildingFNameText;
    [SerializeField] TMP_Text buildingAGoldText, buildingBGoldText, buildingCGoldText, buildingDGoldText, buildingEGoldText, buildingFGoldText;
    [SerializeField] TMP_Text buildingBGemText, buildingCGemText, buildingDGemText, buildingEGemText, buildingFGemText;

    void OnEnable()
    {
        GameManager.Instance.OnResourcesChanged += UpdateGoldGemText;
    }

    void OnDisable()
    {
        GameManager.Instance.OnResourcesChanged -= UpdateGoldGemText;
    }

    void Start()
    {
        UpdateGoldGemText();

        // All the building name, gold and gem cost text fields

        buildingANameText.text = buildingAData.buildingName;
        buildingAGoldText.text = buildingAData.buildingGoldCost.ToString();
        // buildingAGemText.text = buildingAData.buildingGemCost.ToString();

        buildingBNameText.text = buildingBData.buildingName;
        buildingBGoldText.text = buildingBData.buildingGoldCost.ToString();
        buildingBGemText.text = buildingBData.buildingGemCost.ToString();

        buildingCNameText.text = buildingCData.buildingName;
        buildingCGoldText.text = buildingCData.buildingGoldCost.ToString();
        buildingCGemText.text = buildingCData.buildingGemCost.ToString();

        buildingDNameText.text = buildingDData.buildingName;
        buildingDGoldText.text = buildingDData.buildingGoldCost.ToString();
        buildingDGemText.text = buildingDData.buildingGemCost.ToString();

        buildingENameText.text = buildingEData.buildingName;
        buildingEGoldText.text = buildingEData.buildingGoldCost.ToString();
        buildingEGemText.text = buildingEData.buildingGemCost.ToString();

        buildingFNameText.text = buildingFData.buildingName;
        buildingFGoldText.text = buildingFData.buildingGoldCost.ToString();
        buildingFGemText.text = buildingFData.buildingGemCost.ToString();
    }

    public void UpdateGoldGemText()
    {
        goldText.text = GameManager.Instance.gold.ToString();
        gemText.text = GameManager.Instance.gems.ToString();
    }
}
