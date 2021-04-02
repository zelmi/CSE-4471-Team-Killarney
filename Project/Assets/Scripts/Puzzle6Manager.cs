using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Xml;

public class Puzzle6Manager : MonoBehaviour
{
    public class Message {
        public string senderOrRecipient;
        public string subject;
        public string time;
        public string text;

        public Message(string senderOrRecipient, string subject, string time, string text)
        {
            this.senderOrRecipient = senderOrRecipient;
            this.subject = subject;
            this.time = time;
            this.text = text;
        }
    }
    //Message data
    private List<Message> inboxData;
    private List<Message> sentData;
    private List<Message> spamData;
    private List<Message> trashData;

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
        InitializeMessages();
    }

    public void OnClickEmailClose()
    {
        emailMessageText.SetActive(false);
    }
    public void OnClickComposeClose()
    {
        emailComposeWindow.SetActive(false);
    }

    public void OnClickEmailCategory(string type)
    {
        List<Message> currentData = inboxData;

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

    public void EmailItemEvent(List<Message> sourceList, int index)
    {
        emailMessageText.SetActive(true);

        //Special case email was from sent
        if (sourceList == sentData)
        {
            emailMessageText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "hr.alice@bmail.com";
            emailMessageText.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = sourceList[index].senderOrRecipient;

        } else
        {
            emailMessageText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = sourceList[index].senderOrRecipient;
            emailMessageText.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "hr.alice@bmail.com";
        }

        emailMessageText.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = sourceList[index].subject;
        emailMessageText.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = sourceList[index].text.Replace("~", Environment.NewLine);
    }

    void InstantiateMessages(List<Message> messageList)
    {
        //Clear list
        for(int i = 0; i < emailMessageList.transform.childCount; i++)
        {
            Destroy(emailMessageList.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < messageList.Count; i++)
        {
            GameObject messageObj = Instantiate(message, emailMessageList.transform);
            messageObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -47 - 20 * i, 0);
            messageObj.transform.GetChild(0).GetComponent<TMP_Text>().SetText(messageList[i].senderOrRecipient);
            messageObj.transform.GetChild(1).GetComponent<TMP_Text>().SetText(messageList[i].subject);
            messageObj.transform.GetChild(2).GetComponent<TMP_Text>().SetText(messageList[i].time);

            //Must make a copy of i, else the EmailItemEvent will break
            int index = i;
            messageObj.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => EmailItemEvent(messageList, index));
        }
    }
    async void InitializeMessages()
    {
        inboxData = new List<Message>();
        sentData = new List<Message>();
        spamData = new List<Message>();
        trashData = new List<Message>();

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Async = true;

        List<Message> currentData = inboxData;

        //Forward only, that is, depth first
        using (XmlReader reader = XmlReader.Create("Assets/Data/emailData.xml", settings))
        {
            while (await reader.ReadAsync())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "category":
                            switch (reader.GetAttribute("type"))
                            {
                                case "inbox":
                                    currentData = inboxData;
                                    break;
                                case "sent":
                                    currentData = sentData;
                                    break;
                                case "spam":
                                    currentData = spamData;
                                    break;
                                case "trash":
                                    currentData = trashData;
                                    break;
                            }
                            break;
                        case "message":
                            string senderOrRecipient = reader.GetAttribute("senderOrRecipient");
                            string subject = reader.GetAttribute("subject");
                            string time = reader.GetAttribute("time");
                            string text = reader.GetAttribute("text");

                            currentData.Add(new Message(senderOrRecipient, subject, time, text));
                            break;
                    }
                }
            }
        }

        //Default
        InstantiateMessages(inboxData);
    }
    public void OnClickCompose()
    {
        emailComposeWindow.SetActive(true);
    }

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
