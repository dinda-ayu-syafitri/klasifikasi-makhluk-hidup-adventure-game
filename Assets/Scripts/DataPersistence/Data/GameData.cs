using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;

    public GameData()
    {
        this.totalPoints = 0;
        this.emblemCollected = 0;
    }
}