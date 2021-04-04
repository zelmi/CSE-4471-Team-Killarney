using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle2HiddenMessage : MonoBehaviour
{
    public GameObject canvas1;

    public GameObject canvas2;

    public GameObject canvas3;

    public TMP_InputField enteredCode;

    public void OnEnterCode()
    {
        string expectedCode = "twibbsrmmtpahm";
        string x = enteredCode.text;

        if (
            expectedCode
                .IndexOf(x, 0, StringComparison.CurrentCultureIgnoreCase) !=
            -1
        )
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
        }
        else
        {
            canvas1.SetActive(false);
            canvas3.SetActive(true);
        }
    }

    public void ifFail()
    {
        canvas3.SetActive(false);
        canvas1.SetActive(true);
    }

    public void ifSuccess()
    {
        //proceed to next part where the door is open
    }

    // expectedCode
    //     .Equals(enteredCode,
    //     StringComparison.InvariantCultureIgnoreCase)

    // public void OnClickCompleteProcess() {
    //     PuzzleSceneManager.SceneSwitch("DecryptedSSLScene");
    // }
}
