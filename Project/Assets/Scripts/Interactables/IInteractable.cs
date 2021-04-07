using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Edited version of code from tutorial by VeryHotShark on youtube

public interface IInteractable
{
    bool IsInteractable{ get; }
    string HoverMessage{ get; }
    void onInteract();
}
