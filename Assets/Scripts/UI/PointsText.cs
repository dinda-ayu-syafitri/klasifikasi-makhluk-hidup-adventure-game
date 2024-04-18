using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsText : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int totalPoints = 0;

    private int emblemCollected = 0;

    private TextMeshProUGUI pointsText;

    private void Awake()
    {
        pointsText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData data)
    {
        this.totalPoints = data.totalPoints;
        this.emblemCollected = data.emblemCollected;
    }

    public void SaveData(GameData data)
    {
        data.totalPoints = this.totalPoints;
        data.emblemCollected = this.emblemCollected;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.instance.onEmblemCollected += OnEmblemCollected;
        GameEventManager.instance.onFalseEmblemCollected += OnFalseEmblemCollected;
    }

    private void OnDestroy()
    {
        GameEventManager.instance.onEmblemCollected -= OnEmblemCollected;
        GameEventManager.instance.onFalseEmblemCollected -= OnFalseEmblemCollected;
    }

    private void OnEmblemCollected()
    {
        emblemCollected++;
        totalPoints += 100;
        // Debug.Log("Points: " + totalPoints);
        // Debug.Log("Emblems: " + emblemCollected);
    }
    private void OnFalseEmblemCollected()
    {
        totalPoints -= 100;
        Debug.Log("FALSE EMBLEM COLLECTED! Points: " + totalPoints);
    }
    // Update is called once per frame
    void Update()
    {
        pointsText.text = totalPoints.ToString();
    }
}
