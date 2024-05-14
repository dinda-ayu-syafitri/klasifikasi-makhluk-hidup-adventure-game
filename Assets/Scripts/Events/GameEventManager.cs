using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }
    public GameObject playerPrefab; // Reference to the player prefab

        private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

        if (GameObject.FindGameObjectWithTag("Player") == null && playerPrefab != null)
        {
            GameObject playerObject = Instantiate(playerPrefab);
            DontDestroyOnLoad(playerObject);
        }
    }



    // private void Start()
    // {
    //     // Instantiate player object only if it doesn't exist in the scene
    //     if (GameObject.FindGameObjectWithTag("Player") == null && playerPrefab != null)
    //     {
    //         GameObject playerObject = Instantiate(playerPrefab);
    //         DontDestroyOnLoad(playerObject);
    //     }
    // }

    // Add other methods for managing scene transitions, saving/loading game data, etc.

    // public event Action onPlayerDeath;
    // public void PlayerDeath() 
    // {
    //     if (onPlayerDeath != null) 
    //     {
    //         onPlayerDeath();
    //     }
    // }

    public event Action onEmblemCollected;
    public void EmblemCollected() 
    {
        if (onEmblemCollected != null) 
        {
            onEmblemCollected();
        }
    }
    public event Action onFalseEmblemCollected;
    public void FalseEmblemCollected() 
    {
        if (onFalseEmblemCollected != null) 
        {
            onFalseEmblemCollected();
        }
    }

    public event Action onPowerUpCollected;
    public void PowerUpCollected() 
    {
        if (onPowerUpCollected != null) 
        {
            onPowerUpCollected();
        }
    }

    public event Action onTimeUp;
    public void TimeUp()
    {
        if (onTimeUp != null)
        {
            onTimeUp();
        }
    }
}
