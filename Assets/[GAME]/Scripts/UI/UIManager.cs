using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text gemText;

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
    }

    public void UpdateGoldGemText()
    {
        goldText.text = GameManager.Instance.gold.ToString();
        gemText.text = GameManager.Instance.gems.ToString();
    }
}
