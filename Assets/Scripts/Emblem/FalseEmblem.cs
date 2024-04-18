using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseEmblem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();

    }
    
    bool collected = false;

    public void LoadData(GameData gameData)
    {
        gameData.falseEmblemItemCollected.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if (gameData.falseEmblemItemCollected.ContainsKey(id))
        {
            gameData.falseEmblemItemCollected.Remove(id);
        }
        gameData.falseEmblemItemCollected.Add(id, collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
        {
            CollectFalseEmblem();
        }
    }

    private void CollectFalseEmblem()
    {
        collected = true;
        Destroy(gameObject);
        GameEventManager.instance.FalseEmblemCollected();
        Debug.Log("FALSE EMBLEM COLLECTED!");
    }
}
