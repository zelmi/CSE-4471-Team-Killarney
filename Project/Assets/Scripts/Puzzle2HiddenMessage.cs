using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle2HiddenMessage : MonoBehaviour
{
    public GameObject canvas1;

    public GameObject canvas2;

    public GameObject canvas3;

    public TMP_InputField enteredCode;

    public void OnClick()
    {
        PuzzleSceneManager.ExitPuzzle();
    }
}
