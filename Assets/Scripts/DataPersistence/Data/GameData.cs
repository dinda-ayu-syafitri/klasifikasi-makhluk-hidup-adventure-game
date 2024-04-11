using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;
    public Vector3 playerPosition;

    public GameData()
    {
        this.totalPoints = 0;
        this.emblemCollected = 0;
        this.playerPosition = new Vector3(20f, 4.5f, -53f);
    }
}