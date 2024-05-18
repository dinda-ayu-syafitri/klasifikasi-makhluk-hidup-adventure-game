using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;
    public int falseEmblemCollected;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> emblemItemCollected;
    public SerializableDictionary<string, bool> falseEmblemItemCollected;
    public SerializableDictionary<string, bool> powerUpUsed;
    public string currentScene;
    
    public GameData()
    {
        this.totalPoints = 0;
        this.emblemCollected = 0;
        this.playerPosition = new Vector3(17.949f, -1.421f, -9.58f);
        this.currentScene = "1 - Lobby";
        this.emblemItemCollected = new SerializableDictionary<string, bool>();
        this.falseEmblemItemCollected = new SerializableDictionary<string, bool>();
        this.powerUpUsed = new SerializableDictionary<string, bool>();
        this.falseEmblemCollected = 0;
    }

    public int GetPercentageCompleted()
    {
        switch (currentScene)
        {
            case "1 - Lobby":
                return 0;
            case "Lobby 1":
                return 20;
            case "Video Materi 1":
                return 40;
            case "Video Materi 2":
                return 60;
            case "Video Materi 3":
                return 70;
            case "Video Materi 4":
                return 80;
            case "Video Materi 5":
                return 90;
            case "Complete Scene":
                return 100;
            default:
                return -1;
        }
    }
}