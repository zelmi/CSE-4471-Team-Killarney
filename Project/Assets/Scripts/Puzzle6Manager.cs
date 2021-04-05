using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using Assets.Scripts;
using System.IO;

public class Puzzle6Manager : MonoBehaviour
{
    //Game controller object
    private GameObject gameController;

    //Message data
    public EmailInbox inboxData;
    public EmailInbox sentData;
    public EmailInbox spamData;
    public EmailInbox trashData;

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

    //Email GameObject references
    public GameObject emailComposeWindow;
    public GameObject emailMessageList;
    public GameObject emailMessageText;

    //Message item prefab for instantiating list
    public GameObject message;

    void Start()
    {
        //Get the game controller
        gameController = GameObject.FindGameObjectWithTag("GameController");

        InitializeMessages();

    }

    //Event handler for closing email
    public void OnClickEmailClose()
    {
        emailMessageText.SetActive(false);
    }

    //Event handler for closing compose window
    public void OnClickComposeClose()
    {
        emailComposeWindow.SetActive(false);
    }

    //Event handler for closing window
    public void OnClose()
    {
        PuzzleSceneManager.ExitPuzzle();
    }

    //Event handler for opening inboxes
    public void OnClickEmailCategory(string type)
    {
        EmailInbox currentData = inboxData;

        switch (type)
        {
            case "Sent":
                currentData = sentData;
                break;
            case "Spam":
                currentData = spamData;
                break;
            case "Trash":
                currentData = trashData;
                break;
        }

        InstantiateMessages(currentData);
    }

    //Event handler for opening an email
    public void EmailItemEvent(EmailInbox sourceList, int index)
    {
        emailMessageText.SetActive(true);

        //Special case email was from sent
        if (sourceList.type == "Sent")
        {
            emailMessageText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "martens.alice@bmail.com";
            emailMessageText.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = sourceList.messageList[index].senderOrRecipient;

        } else
        {
            emailMessageText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = sourceList.messageList[index].senderOrRecipient;
            emailMessageText.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "martens.alice@bmail.com";
        }

        emailMessageText.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = sourceList.messageList[index].subject;
        emailMessageText.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = sourceList.messageList[index].text.Replace("~", Environment.NewLine);
    }

    //Populate message list with messages
    void InstantiateMessages(EmailInbox messageList)
    {
        //Clear list
        for(int i = 0; i < emailMessageList.transform.childCount; i++)
        {
            Destroy(emailMessageList.transform.GetChild(i).gameObject);
        }

        //Add messages
        for (int i = 0; i < messageList.messageList.Count; i++)
        {
            GameObject messageObj = Instantiate(message, emailMessageList.transform);
            messageObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -47 - 20 * i, 0);
            messageObj.transform.GetChild(0).GetComponent<TMP_Text>().SetText(messageList.messageList[i].senderOrRecipient);
            messageObj.transform.GetChild(1).GetComponent<TMP_Text>().SetText(messageList.messageList[i].subject);
            messageObj.transform.GetChild(2).GetComponent<TMP_Text>().SetText(messageList.messageList[i].time);

            //Must make a copy of i, else the EmailItemEvent will break
            int index = i;
            messageObj.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => EmailItemEvent(messageList, index));
        }
    }

    //Load messages from data into EmailInboxes
    void InitializeMessages()
    {
        //Inbox
        XmlSerializer serialize = new XmlSerializer(typeof(EmailInbox));
        FileStream file = new FileStream(Application.streamingAssetsPath + "/Data/inbox.xml", FileMode.Open);
        inboxData = (EmailInbox)serialize.Deserialize(file);

        //Sent
        file = new FileStream(Application.streamingAssetsPath + "/Data/sent.xml", FileMode.Open);
        
        //If there is new sent data, then use that instead
        if (File.Exists(Application.streamingAssetsPath + "/Data/newsent.xml"))
        {
            file = new FileStream(Application.streamingAssetsPath + "/Data/newsent.xml", FileMode.Open);
        }
        sentData = (EmailInbox)serialize.Deserialize(file);

        //Spam
        file = new FileStream(Application.streamingAssetsPath + "/Data/spam.xml", FileMode.Open);
        spamData = (EmailInbox)serialize.Deserialize(file);

        //Trash
        file = new FileStream(Application.streamingAssetsPath + "/Data/trash.xml", FileMode.Open);
        trashData = (EmailInbox)serialize.Deserialize(file);

        //More sanity checking
        if (gameController != null)
        {
            if (gameController.GetComponent<GameController>().PhishingResponse)
            {
                //Load phishing response
                XmlSerializer ser = new XmlSerializer(typeof(EmailInbox.Message));
                file = new FileStream(Application.streamingAssetsPath + "/Data/phishingresponse.xml", FileMode.Open);
                EmailInbox.Message phishingResponse = (EmailInbox.Message)ser.Deserialize(file);

                //Get time for the response
                phishingResponse.time = GetTime();

                //Add to inbox
                inboxData.messageList.Insert(0, phishingResponse);
            }
        }

        //Default to inbox
        InstantiateMessages(inboxData);
    }

    //Event handler for opening compose window
    public void OnClickCompose()
    {
        emailComposeWindow.SetActive(true);
    }

    //Event handler for send
    public void OnClickSend()
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

        //Good email
        if (conditionsPassed)
        {
            if(gameController != null)
            {
                gameController.GetComponent<GameController>().PhishingPuzzle = true;
            }
        }

        //Adding sent email to sent list
        EmailInbox.Message newSent = new EmailInbox.Message(to, subject, GetTime(), message);
        sentData.messageList.Insert(0, newSent);

        //Serialize
        XmlSerializer serializer = new XmlSerializer(typeof(EmailInbox));
        TextWriter writer = new StreamWriter(Application.streamingAssetsPath + "/Data/newsent.xml");
        serializer.Serialize(writer, sentData);

        //Close and clear email compose window
        toField.text = "";
        subjectField.text = "";
        messageField.text = "";
        OnClickComposeClose();
    }

    //Gets the "current" time
    string GetTime()
    {
        return "7:" + (29 + (int)(30 - gameController.GetComponent<GameController>().timer.TimeRemaining / 60)) + "pm";
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
