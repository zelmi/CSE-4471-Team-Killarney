using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Edited version of code from tutorial by VeryHotShark on youtube

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
