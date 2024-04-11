using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsText : MonoBehaviour
{
    [SerializeField] private int totalPoints = 0;

    private int emblemCollected = 0;

    private TextMeshProUGUI pointsText;

    private void Awake()
    {
        pointsText = this.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.instance.onEmblemCollected += OnEmblemCollected;
    }

    private void OnDestroy()
    {
        GameEventManager.instance.onEmblemCollected -= OnEmblemCollected;
    }

    private void OnEmblemCollected()
    {
        emblemCollected++;
        totalPoints += 100;
        Debug.Log("Points: " + totalPoints);
        Debug.Log("Emblems: " + emblemCollected);
    }
    // Update is called once per frame
    void Update()
    {
        pointsText.text = totalPoints.ToString();
    }
}
