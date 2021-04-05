using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionsStorage : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private string lockedHoverMessage;
    [SerializeField] private string unlockedHoverMessage;
    [SerializeField] private string scene;

    //interavtability variable, set based on interaction
    private bool isInteractable;
    private Animator _anim;
    private GameObject gameController;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { 
        get {
            if(!gameController.GetComponent<GameController>().StorageUnlocked){
                return lockedHoverMessage;
            } else {
                return unlockedHoverMessage;
            }
        }
    }

    public void onInteract()
    {
        if(!gameController.GetComponent<GameController>().StorageUnlocked){
            PuzzleSceneManager.SwitchToPuzzle(scene);
        } else {
            _anim.SetBool("hasBeenOpened", true);
            isInteractable = false;
        }
    }

    void Start()
    {
        isInteractable = true;
        _anim = this.transform.GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

}
