using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class BossPasswordScript : MonoBehaviour
{
    public TMP_InputField password;
    
    //Probably should be private readonly, but we still need to figure out the final password, so leave public to change and test in Unity for now
    public string expectedPassword;


    void Update() {
        // if (Input.GetKeyDown(KeyCode.Return)) {
        //     OnClick();
        // }
    }

    public void OnClick()
    {
        if (password.text == expectedPassword)
        {
            //Disable interaction
            password.interactable = false;

            //Go to email puzzle
            PuzzleSceneManager.SwitchToPuzzle("ShutdownSecurityScene");
        }
        password.text = "";
    }
}
