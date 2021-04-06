using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    public Inventory Inventory {get; set;}
    
    // Puzzle is complete once first computer is unlocked using post it note password: 01
    public bool PostItPuzzle {get; set;} 

    //Puzzle is complete when storage room is unlocked with keycode: 02
    public bool UnlockStorageRoomPuzzle {get; set;}

    //Puzzle is complete once messsage is decoded with sslStrip: 03
    public bool SSLStripPuzzle {get; set;}

    //Puzzle is complete once network traffic is found using packetsniffer commands: 04 
    public bool PacketSnifferPuzzle {get; set;}

    //Puzzle is complete once managers office is unlocked using keypad: 05 
    public bool UnlockManagersOfficePuzzle {get; set;}

    //Puzzle is complete once logged into managers computer after guessing password: 05 
    public bool DisableManagersSeecurityProtectionPuzzle {get; set;}

    //Puzzle is complete after sending phishing email to employee from post it note computer : 06
    //Dependent on puzzle 1 being completed, and employee files being found
    public bool PhishingPuzzle {get; set;}

    //Puzzle is complete once virus is uploaded to network: 07 
    public bool VirusDisablesProtectionPuzzle {get; set;}

    //Puzzle is complete once ddos attack is sent from computer unlocked via phishing puzzle: 08
    //Dependent on puzzle 06
    public bool DDoSPuzzle {get; set;}

    //Signals if all puzzles are complete and server room door can be opened
    public bool ServerRoomOpen {get; private set;}

    //Tracks whether the response to the phishing email from puzzle 6 has been sent
    public bool PhishingResponse { get; set; }

    //tracks whether the storage room door is unlocked
    public bool StorageUnlocked{ get; set; }

    //tracks whether the Manager's room door is unlocked
    public bool BossUnlocked{ get; set; }

    //Tracks whether the player has found the USB stick in the storage room, and whether they have downloaded the virus onto it

    public static bool PlayerHasUsb{ get; set; }
    public static bool USBHasVirus{ get; set; }

    private bool alarmCountdownInitiated;

    private bool InLoseState;
    private bool InWinState;

    public Timer timer;
    public TMP_Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(timeText.transform.parent.gameObject);

        // timer = gameObject.AddComponent(typeof(Timer)) as Timer; 
        timer = new Timer(1800);
        //timeText =  GetComponent<Text>();
        Inventory = gameObject.AddComponent(typeof(Inventory)) as Inventory;
        ResetBooleans();
    }

    //Sets initial values for booleans
    public void ResetBooleans()
    {
        PostItPuzzle = false;
        UnlockStorageRoomPuzzle = false;
        SSLStripPuzzle = false;
        PacketSnifferPuzzle = false;
        UnlockManagersOfficePuzzle = false;
        DisableManagersSeecurityProtectionPuzzle = false;
        PhishingPuzzle = false;
        VirusDisablesProtectionPuzzle = false;
        DDoSPuzzle = false;
        alarmCountdownInitiated = false;
        PhishingResponse = false;
        InLoseState = false;
        InWinState = false;
        StorageUnlocked = false;
        BossUnlocked = false;
        ServerRoomOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer.UpdateTime();
        DisplayTime(timer.TimeRemaining);
        if (timer.TimeRemaining <= 0) {
            //Lose State 
            ActivateLoseState();
        }
        if (!alarmCountdownInitiated) {
            if (VirusDisablesProtectionPuzzle && DisableManagersSeecurityProtectionPuzzle) {
                // 5 minutes
                timer = new Timer(300);
                alarmCountdownInitiated = true;
            }
        } else {
            if(DDoSPuzzle){
                alarmCountdownInitiated = false;
                ServerRoomOpen = true;
            }
        }

        /*if(Keyboard.current.spaceKey.isPressed)
        {
            ActivateWinState();
        }*/
    }

    public void ActivateLoseState() {
        if (!InLoseState)
        {
            InLoseState = true;
            timeText.transform.parent.gameObject.SetActive(false);
            PuzzleSceneManager.SceneSwitch("LoseScene");
        }
    }

    public void ActivateWinState() {
        if (!InWinState)
        {
            InWinState = true;
            timer.timerIsRunning = false;
            timeText.transform.parent.gameObject.SetActive(false);
            PuzzleSceneManager.SceneSwitch("WinScene");
        }
    }

    private void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartGame() {
        //Main room
        PuzzleSceneManager.SceneSwitch("GameScene");

        //Reset booleans
        ResetBooleans();

        //Starting timer
        timer.ResetTime();
        timeText.transform.parent.gameObject.SetActive(true);
        timer.timerIsRunning = true;
    }

    public void QuitGame() {
        PuzzleSceneManager.QuitGame();
    }
}
