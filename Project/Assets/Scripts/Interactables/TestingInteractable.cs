using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInteractable : MonoBehaviour, IInteractable
{
    public bool IsInteractable { get; set; }

    public string HoverMessage { get; set; }

    public void onInteract()
    {
        Debug.Log(HoverMessage);
    }

    void Start()
    {
        IsInteractable = true;
        HoverMessage = "Hello World!";
    }
}
