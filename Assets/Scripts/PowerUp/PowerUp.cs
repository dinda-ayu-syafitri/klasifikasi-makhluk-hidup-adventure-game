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


    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();

    }
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
            StartCoroutine(ActivatePowerUp());
            CollectPowerUps();
        }
    }

    private IEnumerator ActivatePowerUp()
    {
        collected = true;
        playerController.playerSpeed = 10.0f;
    GetComponent<Renderer>().enabled = false;


        yield return new WaitForSeconds(10);

        playerController.playerSpeed = 5.0f;
        Debug.Log("POWER UP DEACTIVATED!");
        GameEventManager.instance.PowerUpCollected();

        Destroy(gameObject); 


    }


    private void CollectPowerUps()
    {
        // collected = true;
        // Destroy(gameObject);
        // GameEventManager.instance.PowerUpCollected();
        Debug.Log("POWER UP COLLECTED!");
    }
}
