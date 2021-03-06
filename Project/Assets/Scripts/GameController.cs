using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

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

    //Will be used once player triggers the countdown
    public GameObject redFilter;

    private GameObject redFilterInstance;

    // Start is called before the first frame update
    void Start()
    {
        //Locking cursor to the window
        Cursor.lockState = CursorLockMode.Confined;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(timeText.transform.parent.gameObject);

        timer = new Timer(1800);
        ResetBooleans();
    }

    //Sets initial values for booleans
    public void ResetBooleans()
    {
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
                if(timer.TimeRemaining > 300){
                    timer.TimeRemaining = 300;
                }
                alarmCountdownInitiated = true;

                //Adds red filter
                redFilterInstance = Instantiate(redFilter);
            }
        } else {
            if(DDoSPuzzle){
                Destroy(redFilterInstance);
                ServerRoomOpen = true;
            }
        }

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
