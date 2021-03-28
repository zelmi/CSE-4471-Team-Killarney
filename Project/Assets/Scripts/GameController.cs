using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool alarmCountdownInitiated;

    public Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        // timer = gameObject.AddComponent(typeof(Timer)) as Timer; 
        Inventory = gameObject.AddComponent(typeof(Inventory)) as Inventory; 
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

    }

    // Update is called once per frame
    void Update()
    {
        if (!alarmCountdownInitiated) {
            if (VirusDisablesProtectionPuzzle && DisableManagersSeecurityProtectionPuzzle) {
                // 5 minutes
                // timer.TimeRemaining = 300;
            }
        }
    }
}
