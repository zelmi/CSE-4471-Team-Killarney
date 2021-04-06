using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class SecurityShutdownScript : MonoBehaviour
{
    public void OnClickPower()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DisableManagersSeecurityProtectionPuzzle = true;
        PuzzleSceneManager.ExitPuzzle();
        // Change gamecontroller flag
    }

    public void OnClickCancel()
    {
        PuzzleSceneManager.SwitchToPuzzle("PasswordScene");
    }
}
