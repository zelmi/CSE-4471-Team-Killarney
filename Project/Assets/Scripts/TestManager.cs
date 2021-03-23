﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PuzzleSceneManager.SwitchToPuzzle("TestPuzzle");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PuzzleSceneManager.ExitPuzzle();
        }
    }
}
