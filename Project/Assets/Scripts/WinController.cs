using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinController : MonoBehaviour
{
    public GameControllerProxy proxy;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        Timer timer = proxy.GetTimer();
        float elapsedTime = timer.StartTime - timer.TimeRemaining;
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
