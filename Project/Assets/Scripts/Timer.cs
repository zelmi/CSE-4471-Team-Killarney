using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// static timer class
public class Timer
{
    public float StartTime { get; set; }
    public float TimeRemaining {get; set;}
    public bool timerIsRunning = false;


    public Timer(int startTime) {
        // Starts the timer automatically
        timerIsRunning = false;
        StartTime = startTime;
        //30 minutes
        TimeRemaining = startTime;
    }

    public void ResetTime()
    {
        timerIsRunning = false;
        TimeRemaining = StartTime;
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

}