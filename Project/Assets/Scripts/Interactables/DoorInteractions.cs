using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractions : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private string lockedHoverMessage;
    [SerializeField] private string unlockedHoverMessage;
    [SerializeField] private string scene;
    private bool isInteractable;
    private Animator _anim;
    private bool isLocked;

    public bool IsInteractable { get => isInteractable; }

    public bool IsLocked { get => isLocked; set => isLocked = value; }

    public string HoverMessage { 
        get {
            if(isLocked){
                return lockedHoverMessage;
            } else {
                return unlockedHoverMessage;
            }
        }
    }

    public void onInteract()
    {
        if(isLocked){
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
        isLocked = false;
    }
}
