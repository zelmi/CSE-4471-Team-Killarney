using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoverUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hoverText;

    public void SetHoverMessage(string message) {
        hoverText.SetText(message);
    }

    public void ResetUI(){
        hoverText.SetText("");
    }
}
