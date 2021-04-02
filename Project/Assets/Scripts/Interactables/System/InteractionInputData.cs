using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "Interactions/InputData")]
public class InteractionInputData : ScriptableObject
{
    public bool p_interactPress;
    //private bool p_interactRelease;

    public bool InteractPress {
        get => p_interactPress;
        set => p_interactPress = value;
    }

    /*public bool InteractRelease {
        get => p_interactPress;
        set => p_interactRelease = value;
    }*/

    public void Reset(){
        p_interactPress = false;
        //p_interactRelease = false;
    }
}
