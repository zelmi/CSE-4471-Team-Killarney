using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// static timer class
public class Timer
{
    public float TimeRemaining {get; set;}
    public bool timerIsRunning = false;
    public Text timeText;


    public Timer(int startTime) {
        // Starts the timer automatically
        timerIsRunning = true;
        //30 minutes
        TimeRemaining = startTime;
    }

    public void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        //30 minutes
        TimeRemaining = 1800;
    }

    public void UpdateTime()
    {
        if (timerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}