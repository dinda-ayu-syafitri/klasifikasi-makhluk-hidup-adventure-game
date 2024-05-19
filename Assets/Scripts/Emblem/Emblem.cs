using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Emblem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();

    }
    bool collected = false;

  private TextMeshPro organismText;
    public string organismName;

        private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public Sprite emblemImage; // Image to be assigned to SpriteRenderer

 private void Awake()
    {
        Debug.Log("Emblem Awake method called.");
        organismText = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (organismText == null)
        {
            Debug.LogError("TextMeshPro component not found in children of the Emblem object.");
        }
        else
        {
            Debug.Log("TextMeshPro component found in Awake.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found in the Emblem object.");
        }
        else
        {
            Debug.Log("SpriteRenderer component found in Awake.");
        }

        Debug.Log("Emblem GameObject active status in Awake: " + gameObject.activeInHierarchy);
    }

    private void Start()
    {
        Debug.Log("Emblem Start method called.");
        Debug.Log("Emblem GameObject active status in Start: " + gameObject.activeInHierarchy);

        if (organismText != null)
        {
            Debug.Log("Setting text of TextMeshPro to organismName: " + organismName);
            organismText.text = organismName;
            Debug.Log("Text set to: " + organismText.text);
        }
        else
        {
            Debug.LogError("TextMeshPro component is null in Start.");
        }

        if (spriteRenderer != null && emblemImage != null)
        {
            Debug.Log("Setting sprite of SpriteRenderer to emblemImage.");
            spriteRenderer.sprite = emblemImage;
        }
        else if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component is null in Start.");
        }
        else if (emblemImage == null)
        {
            Debug.LogError("Emblem image sprite is not assigned.");
        }
    }



    public void LoadData(GameData gameData)
    {
        gameData.emblemItemCollected.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if (gameData.emblemItemCollected.ContainsKey(id))
        {
            gameData.emblemItemCollected.Remove(id);
        }
        gameData.emblemItemCollected.Add(id, collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
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
