using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusComputerScript : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private bool isInteractable;
    [SerializeField] private string hoverMessage;

    private GameObject gameController;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { get => hoverMessage; }

    public void onInteract()
    {
        //player has usb with virus
        if(GameController.PlayerHasUsb && GameController.USBHasVirus){
            //remove one of the locks
            gameController.GetComponent<GameController>().VirusDisablesProtectionPuzzle = true;
            isInteractable = false;
        }
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
}
