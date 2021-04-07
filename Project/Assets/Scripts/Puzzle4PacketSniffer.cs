using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle4PacketSniffer : MonoBehaviour
{
    public GameObject canvas1;

    public GameObject canvas2;

    public GameObject canvas3;

    public GameObject canvas4;

    public GameObject canvas5;

    public GameObject canvas6;

    public TMP_InputField FirstCommand;

    public TMP_InputField SecondCommand;

    public TMP_InputField ThirdCommand;

    public TMP_InputField FourthCommand;

    public void OnEnterFirstCommand()
    {
        string expectedFirstCommand = "pktmon";
        string x = FirstCommand.text;

        if (
            expectedFirstCommand
                .IndexOf(x, 0, StringComparison.CurrentCultureIgnoreCase) !=
            -1
        )
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
        }
    }

    public void OnEnterSecondCommand()
    {
        string expectedSecondCommand = "pktmon start --etw";
        string x = SecondCommand.text;

        if (
            expectedSecondCommand
                .IndexOf(x, 0, StringComparison.CurrentCultureIgnoreCase) !=
            -1
        )
        {
            canvas2.SetActive(false);
            canvas3.SetActive(true);
        }
    }

    public void OnEnterThirdCommand()
    {
        string expectedThirdCommand = "pktmon stop";
        string x = ThirdCommand.text;

        if (
            expectedThirdCommand
                .IndexOf(x, 0, StringComparison.CurrentCultureIgnoreCase) !=
            -1
        )
        {
            canvas3.SetActive(false);
            canvas4.SetActive(true);
        }
    }

    public void OnEnterFourthCommand()
    {
        string expectedFourthCommand = "pktmon format pktmon.et1 -o pktmon.txt";
        string x = FourthCommand.text;

        if (
            expectedFourthCommand
                .IndexOf(x, 0, StringComparison.CurrentCultureIgnoreCase) !=
            -1
        )
        {
            canvas4.SetActive(false);
            canvas5.SetActive(true);
        }
    }

    public void OnOpenFile()
    {
        canvas5.SetActive(false);
        canvas6.SetActive(true);
    }

    public void ExitPuzzle(){
        PuzzleSceneManager.ExitPuzzle();
    }
}
