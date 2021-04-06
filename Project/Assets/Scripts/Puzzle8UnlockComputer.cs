using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle8UnlockComputer : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    
    //Probably should be private readonly, but we still need to figure out the final password, so leave public to change and test in Unity for now
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
