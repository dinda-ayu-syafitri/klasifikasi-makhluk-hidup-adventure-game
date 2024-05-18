using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    public float totalTime = 10.0f; 
    private float currentTime;
    public event Action onTimeUp; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Timer Manager in the scene.");
        }
        instance = this;
    }

    void Start()
    {
        currentTime = totalTime;
        InvokeRepeating("Countdown", 1.0f, 1.0f); // Start the countdown
    }

    void Countdown()
    {
        currentTime -= 1.0f;
        if (currentTime <= 0)
        {
            CancelInvoke("Countdown"); // Stop the countdown
            if (onTimeUp != null)
            {
                onTimeUp(); // Trigger event when time runs out
            }
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
