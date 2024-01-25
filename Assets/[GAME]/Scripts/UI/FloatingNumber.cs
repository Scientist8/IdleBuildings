using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingNumber : MonoBehaviour
{
    [SerializeField] TMP_Text floatingText;

    public void SetText(string text)
    {
        floatingText.text = text;
    }
}
