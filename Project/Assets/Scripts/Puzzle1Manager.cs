using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class Puzzle1Manager : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    //Probably should be private readonly, but we still need to figure out the final password, so leave public to change and test in Unity for now
    public string expectedEmail;
    public string expectedPassword;

    public void OnClick()
    {
        if (email.text == expectedEmail && password.text == expectedPassword)
        {
            //Disable interaction
            password.interactable = false;

            //Go to email puzzle
            PuzzleSceneManager.SwitchToPuzzle("6.PhishingEmail");
        }
    }
}
