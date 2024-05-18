using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class MissionTimerText : MonoBehaviour
{
    public  TextMeshProUGUI timerText;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TimerText is not assigned in the inspector");
        }
    }

    void Update()
    {
        // Ensure TimerManager instance exists and get the current time
        if (TimerManager.instance != null)
        {
            float currentTime = TimerManager.instance.GetCurrentTime();
            // Format the time as minutes and seconds
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
