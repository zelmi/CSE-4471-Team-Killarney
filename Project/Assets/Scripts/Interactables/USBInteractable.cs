using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBInteractable : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    private bool isInteractable;
    [SerializeField] private string hoverMessage;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { get => hoverMessage; }

    public void onInteract()
    {
        isInteractable = false;
        GameController.PlayerHasUsb = true;
        
        gameObject.SetActive(false);
    }

    void Start()
    {
        isInteractable = true;
    }
}