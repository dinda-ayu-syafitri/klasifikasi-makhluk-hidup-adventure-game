using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpIndicator : MonoBehaviour
{
    [SerializeField] private string PowerUpStatus = "No Power Up";
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
        PowerUpStatus = "Power Up Collected";
    }
    void Update()
    {
        powerUpStatusText.text = PowerUpStatus;
    }
    }

