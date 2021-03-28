using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionData : ScriptableObject {
    private IInteractable p_interactObj;

    public IInteractable Interactable {
        get => p_interactObj;
        set{p_interactObj = value;}
    }

    public void Interact(){
        p_interactObj.onInteract();
    }

    public bool IsSameObj(IInteractable newObj) => newObj == p_interactObj;
    public bool IsEmpty() => p_interactObj == null;
    public void Reset() => p_interactObj = null;


}
