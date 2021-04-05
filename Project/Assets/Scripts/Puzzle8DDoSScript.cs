using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle8DDoSScript : MonoBehaviour
{
    // Start is called before the first frame update

    System.Random random;
    List<string> invalidIPs;
    List<string> validIPs;
    List<Text> IPtexts;

    public Text IP0;
    public Text IP1;
    public Text IP2; 

    public Text answerStatus;
    public Text zombieCountText;

    public GameObject minigameScreen;
    public GameObject winScreen;

    int zombiesCt;
    int correctIP;
    bool needNewSet;
    float timeForSet;
    string lastAnswer;
    private static int MAX_TIME = 10;
    private static string INCORRECT = "incorrect";
    private static string CORRECT = "correct";

    void Start()
    {
        initializeLists();
        timeForSet = MAX_TIME;
        zombiesCt  = 0;
        IPtexts.Add(IP0);
        IPtexts.Add(IP1);
        IPtexts.Add(IP2);
        random = new System.Random();
        needNewSet = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(timeForSet > 0) {
            timeForSet -= Time.deltaTime;
            
        }else {
            needNewSet = true;
        }
        if (needNewSet) {
            setIPs();
            needNewSet = false;
            timeForSet = MAX_TIME;
            zombieCountText.text = "zombies - " + zombiesCt;
            answerStatus.text = lastAnswer;
        }   

        if (zombiesCt > 9) {
            minigameScreen.SetActive(false);
            winScreen.SetActive(true);
            StartCoroutine(LeaveScene());
           
        }
    }

    private IEnumerator LeaveScene()
    {  
        yield return new WaitForSeconds(10);
        PuzzleSceneManager.SceneSwitch("GameScene");
    }

    private void setIPs() { 
        correctIP = random.Next(3);
        for(int i=0; i < 3; i++) {
            if (i == correctIP) { 
                IPtexts[i].text = validIPs[random.Next(validIPs.Count)];
            }
            else {
                IPtexts[i].text = invalidIPs[random.Next(invalidIPs.Count)];
            }
        }
    }

    public void OnClickComputer0() {
        if (correctIP == 0) {
            zombiesCt++;
            lastAnswer = CORRECT;
        }
        else {
            lastAnswer = INCORRECT;
        }
        needNewSet = true;
    }

    public void OnClickComputer1() {
        if (correctIP == 1) {
            zombiesCt++;
            lastAnswer = CORRECT;
        }
        else {
            lastAnswer = INCORRECT;
        }
        needNewSet = true;
    }

    public void OnClickComputer2() {
        if (correctIP == 2) {
            zombiesCt++;
            lastAnswer = CORRECT;
        }
        else {
            lastAnswer = INCORRECT;
        }
        needNewSet = true;
    }

    private void initializeLists() {
        invalidIPs = new List<string>();
        validIPs = new List<string>();
        IPtexts = new List<Text>();

        //load incorrect addresses
        invalidIPs.Add("0.1.2.3.4");
        invalidIPs.Add("12.38.2.1000");
        invalidIPs.Add("12.0..540");
        invalidIPs.Add("12.2.330.9");
        invalidIPs.Add("12.10.10.10.");
        invalidIPs.Add("12.5.90.900");
        invalidIPs.Add("1234.0.0.0");
        invalidIPs.Add("12..255.255.255");
        invalidIPs.Add("12.122.176");
        invalidIPs.Add("12.01.250.12");
        invalidIPs.Add("12.10.010.100");
        invalidIPs.Add("12.9.74.1.14");
        invalidIPs.Add("12.9.256.128");
        invalidIPs.Add("12.128.128");
        invalidIPs.Add("12.1y.15.0");
        invalidIPs.Add("12.E.15.120");
        invalidIPs.Add("12.67.15.t4");
        invalidIPs.Add("12.14.1024.1");
        invalidIPs.Add("12.36.2011");
        invalidIPs.Add("12.99.9f.11");

        //load correct addresses
        validIPs.Add("12.12.12.12");
        validIPs.Add("12.255.255.12");
        validIPs.Add("12.10.10.255");
        validIPs.Add("1.2.3.4");
        validIPs.Add("12.100.0.3");
        validIPs.Add("144.11.7.7");
        validIPs.Add("1.1.1.1");
        validIPs.Add("12.248.15.79");
        validIPs.Add("12.0.0.12");
        validIPs.Add("12.99.103.3");
        validIPs.Add("12.33.66.99");
        validIPs.Add("12.120.12.120");
        validIPs.Add("0.0.0.12");
        validIPs.Add("12.19.20.21");
        validIPs.Add("2.2.2.4");
        validIPs.Add("8.88.255.88");
    }
}
