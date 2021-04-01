using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            PuzzleSceneManager.SwitchToPuzzle("1.EmailLogin");
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            PuzzleSceneManager.SwitchToPuzzle("TestPuzzle2");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            PuzzleSceneManager.ExitPuzzle();
        }
    }
}
