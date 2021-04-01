using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Puzzle6Manager : MonoBehaviour
{
    //Send button
    public Button sendButton;

    //Input fields
    public TMP_InputField toField;
    public TMP_InputField subjectField;
    public TMP_InputField messageField;

    //Target desired data, can be set in editor
    public string toTarget;
    public string[] subjectTargets;
    public string[] messageTargets;

    //Target word match counts
    public int subjectMatchCountTarget;
    public int messageMatchCountTarget;

    public void OnClick()
    {
        //Sequentially check if any conditions failed
        bool conditionsPassed = true;

        //Check to field, must be exact
        string to = toField.text;
        if (to != toTarget)
        {
            conditionsPassed = false;
        }

        //Check subject, need to have a certain number of keywords
        string subject = subjectField.text;
        int subjectMatchCount = 0;
        foreach (string targetWord in subjectTargets)
        {
            //Ignore case
            if (subject.IndexOf(targetWord, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                subjectMatchCount++;
            }
        }
        //Failed
        if (subjectMatchCount < subjectMatchCountTarget)
        {
            conditionsPassed = false;
        }

        //Check message, need to have a certain number of keywords
        string message = messageField.text;
        int messageMatchCount = 0;
        foreach (string targetWord in messageTargets)
        {
            //Ignore case
            if (message.IndexOf(targetWord, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                messageMatchCount++;
            }
        }
        //Failed
        if (messageMatchCount < messageMatchCountTarget)
        {
            conditionsPassed = false;
        }

        if (conditionsPassed)
        {
            Debug.Log("Success");
        } else
        {
            Debug.Log("Failure");
        }
    }

    void Update()
    {
        //Enable button if all fields have text
        if (toField.text != "" && subjectField.text != "" && messageField.text != "")
        {
            sendButton.interactable = true;
        } else
        {
            sendButton.interactable = false;
        }
    }
}
