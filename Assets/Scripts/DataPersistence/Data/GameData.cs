using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;
    public int falseEmblemCollected;
    public int currentScenePoints;
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
        this.currentScene = "01 - Intro";
        this.emblemItemCollected = new SerializableDictionary<string, bool>();
        this.falseEmblemItemCollected = new SerializableDictionary<string, bool>();
        this.powerUpUsed = new SerializableDictionary<string, bool>();
        this.falseEmblemCollected = 0;
        this.currentScenePoints = 0;
    }

    public int GetPercentageCompleted()
    {
        switch (currentScene)
        {
            case "1 - Lobby":
                return 0;
            case "2 - Video Animalia":
                return 0;
            case "3 - Area Animalia":
                return 10;
            case "4 - Video Plantae":
                return 20;
            case "5 - Area Plantae":
                return 30;
            case "6 - Video Fungi":
                return 40;
            case "7 - Area Fungi":
                return 50;
            case "8 - Video Protista":
                return 60;
            case "9 - Area Protista":
                return 70;
            case "10 - Video Monera":
                return 80;
            case "11 - Area Monera":
                return 90;
            case "12 - Outro":
                return 100;
            case "13 - Game Over":
                return 100;
            default:
                return 0;
        }
    }
}