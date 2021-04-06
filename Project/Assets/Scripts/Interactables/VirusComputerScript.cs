using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusComputerScript : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private bool isInteractable;
    [SerializeField] private string hoverMessage;
    [SerializeField] private string hoverMessageConfirm;

    //flag for if this is the first time, to allow for the player to confirm before final countdown starts
    private bool _hasClickedBefore;

    private GameObject gameController;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { 
        get{
            if(!_hasClickedBefore){
                return hoverMessage;
            } else {
                return hoverMessageConfirm;
            }
        }
    }

    public void onInteract()
    {
        //player has usb with virus
        if(GameController.PlayerHasUsb && GameController.USBHasVirus){
            if(_hasClickedBefore)
            {
                //remove one of the locks
                gameController.GetComponent<GameController>().VirusDisablesProtectionPuzzle = true;
                gameController.GetComponent<GameController>().PhishingResponse = true;
                isInteractable = false;
            } else {
                _hasClickedBefore = true;
            }
        }
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
}
