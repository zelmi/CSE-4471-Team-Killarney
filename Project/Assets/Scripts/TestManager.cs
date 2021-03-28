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
            PuzzleSceneManager.SwitchToPuzzle("TestPuzzle");
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            PuzzleSceneManager.ExitPuzzle();
        }
    }
}
