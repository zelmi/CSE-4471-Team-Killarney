using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerComputerIneractable : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    private bool _hasHadUSB;
    [SerializeField] private string hoverMessageBeforeUSB;
    [SerializeField] private string hoverMessageAfterUSB;

    public bool IsInteractable { 
        get{
            if(!_hasHadUSB){
                return true;
            } else {
                return true;
            }
        } 
    }

    public string HoverMessage { 
        get{
            if(!_hasHadUSB){
                return hoverMessageBeforeUSB;
            } else {
                return hoverMessageAfterUSB;
            }
        } 
    }

    public void onInteract()
    {
        if(!_hasHadUSB && GlobalVarsAndEvents.PlayerHasUsb){
            _hasHadUSB = true;
            GlobalVarsAndEvents.USBHasVirus = true;
        } else {
            //Intentionally Empty
        }
    }

    void Start()
    {
        _hasHadUSB = false;
    }
}