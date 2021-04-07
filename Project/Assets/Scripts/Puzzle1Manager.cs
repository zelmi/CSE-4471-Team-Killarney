﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class Puzzle1Manager : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    public string expectedEmail;
    public string expectedPassword;

    public void OnClick()
    {
        if (email.text == expectedEmail && password.text == expectedPassword)
        {
            GameObject controller = GameObject.FindGameObjectWithTag("GameController");

            //Disable interaction
            password.interactable = false;

            //Go to email puzzle
            PuzzleSceneManager.SwitchToPuzzle("6.PhishingEmail");
        }
    }

    //Closes the puzzle
    public void OnClose()
    {
        PuzzleSceneManager.ExitPuzzle();
    }
}
