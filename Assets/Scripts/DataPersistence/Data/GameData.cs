using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> emblemItemCollected;
    public string currentScene;

    public GameData()
    {
        this.totalPoints = 0;
        this.emblemCollected = 0;
        this.playerPosition = new Vector3(0f, 1.1f, 0f);
        this.emblemItemCollected = new SerializableDictionary<string, bool>();
        this.currentScene = "Lobby";
    }
}