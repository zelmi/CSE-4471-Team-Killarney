using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinInteractable : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private bool isInteractable;
    [SerializeField] private string hoverMessage;

    private GameObject gameController;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { get => hoverMessage; }

    public void onInteract()
    {
        Debug.Log("ServerRoom Flag:" + gameController.GetComponent<GameController>().ServerRoomOpen);
        //Debug.Log("Alarm Flag:" + gameController.GetComponent<GameController>().ServerRoomOpen);
        Debug.Log("DDOS flag:" + gameController.GetComponent<GameController>().DDoSPuzzle);
        //if server room is open
        if(gameController.GetComponent<GameController>().ServerRoomOpen){
            //win the game
            gameController.GetComponent<GameController>().ActivateWinState();
        }
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
}
