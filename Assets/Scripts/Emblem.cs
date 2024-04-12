using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emblem : MonoBehaviour, IDataPersistence
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
        gameData.emblemItemCollected.TryGetValue(id, out collected);
        if(collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if(gameData.emblemItemCollected.ContainsKey(id))
        {
            gameData.emblemItemCollected.Remove(id);
        }
        gameData.emblemItemCollected.Add(id, collected);
    }
   
   private void OnTriggerEnter(Collider other) {
    if(!collected)
    {
        CollectEmblem();
    }
   }

   private void CollectEmblem()
   {
       collected = true;
       Destroy(gameObject);
       GameEventManager.instance.EmblemCollected();
   }
}
