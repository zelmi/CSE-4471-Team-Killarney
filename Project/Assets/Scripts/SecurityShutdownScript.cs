using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class SecurityShutdownScript : MonoBehaviour
{
    public void OnClickPower()
    {
        PuzzleSceneManager.SceneSwitch("GameScene");
        // Change gamecontroller flag
    }

    public void OnClickCancel()
    {
        PuzzleSceneManager.SceneSwitch("PasswordScene");
    }
}
