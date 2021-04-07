using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Edited version of code from tutorial by VeryHotShark on youtube

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "Interactions/InputData")]
public class InteractionInputData : ScriptableObject
{
    public bool p_interactPress;

    public bool InteractPress {
        get => p_interactPress;
        set => p_interactPress = value;
    }

    public void Reset(){
        p_interactPress = false;
    }
}
