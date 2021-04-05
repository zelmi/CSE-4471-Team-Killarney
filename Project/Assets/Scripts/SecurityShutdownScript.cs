using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class SecurityShutdownScript : MonoBehaviour
{
    public void OnClickPower()
    {
        PuzzleSceneManager.ExitPuzzle();
        // Change gamecontroller flag
    }

    public void OnClickCancel()
    {
        PuzzleSceneManager.SwitchToPuzzle("PasswordScene");
    }
}
