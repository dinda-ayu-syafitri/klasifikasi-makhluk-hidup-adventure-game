using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();

    }
    bool collected = false;
    public GameObject playerPrefab;
    private PlayerController playerController;


    public void LoadData(GameData gameData)
    {
        gameData.powerUpUsed.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if (gameData.powerUpUsed.ContainsKey(id))
        {
            gameData.powerUpUsed.Remove(id);
        }
        gameData.powerUpUsed.Add(id, collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
        {
            CollectPowerUps();
            Debug.Log("Power Up Collected");
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
                Debug.Log("Player Controller Found");
            playerController = playerObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("Player Controller Found");
            }

        }
    }

    private void CollectPowerUps()
    {
        collected = true;
        Destroy(gameObject);
        GameEventManager.instance.PowerUpCollected();
    }
}
