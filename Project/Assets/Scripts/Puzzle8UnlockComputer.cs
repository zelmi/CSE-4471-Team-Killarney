using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle8UnlockComputer : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    
    public string expectedUsername;
    public string expectedPassword;

    public void OnClick()
    {
        Debug.Log("clicked");
        if (username.text == expectedUsername && password.text == expectedPassword)
        {
            //Disable interaction
            password.interactable = false;

            //Go to email puzzle
            PuzzleSceneManager.SwitchToPuzzle("8.DDoSScene");
        }
        password.text = "";
    }

    public void Exit()
    {
        PuzzleSceneManager.ExitPuzzle();
    }
}
