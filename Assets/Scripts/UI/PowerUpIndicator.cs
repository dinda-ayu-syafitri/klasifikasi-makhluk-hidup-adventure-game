using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpIndicator : MonoBehaviour
{
    private TextMeshProUGUI powerUpStatusText;

    private void Awake()
    {
        powerUpStatusText = this.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        GameEventManager.instance.onPowerUpCollected += OnPowerUpCollected;
    }

    private void OnDestroy()
    {
        GameEventManager.instance.onPowerUpCollected -= OnPowerUpCollected;
    }

    private void OnPowerUpCollected()
    {
        // PowerUpStatus = "Power Up Collected";
    }

    void Update()
    {
          PowerUp[] powerUps = FindObjectsOfType<PowerUp>(); // Find all instances of PowerUp
        foreach (PowerUp powerUp in powerUps)
        {
            float remainingTime = powerUp.GetRemainingTime(); // Get the remaining time of each power-up
            powerUpStatusText.text = "Remaining Time: " + remainingTime.ToString("F1"); // Display remaining time
        }

    }
    }

