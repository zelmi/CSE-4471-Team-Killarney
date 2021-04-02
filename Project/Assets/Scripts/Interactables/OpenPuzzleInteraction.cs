using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzleInteraction : MonoBehaviour, IInteractable
{
    [Header("Data Objects")]
    [SerializeField] private bool isInteractable;
    [SerializeField] private string hoverMessage;
    [SerializeField] private string scene;

    public bool IsInteractable { get => isInteractable; }

    public string HoverMessage { get => hoverMessage; }

    public void onInteract()
    {
        PuzzleSceneManager.SwitchToPuzzle(scene);
    }

    void Start()
    {
    }
}
