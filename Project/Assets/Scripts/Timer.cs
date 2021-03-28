using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //30 minutes
    public float TimeRemaining {get; set;}
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        TimeRemaining = 1800;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                DisplayTime(TimeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeRemaining = 0;
                timerIsRunning = false;
            }
        }
        Debug.Log(TimeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}