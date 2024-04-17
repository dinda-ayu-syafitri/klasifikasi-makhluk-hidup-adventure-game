using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]

    [SerializeField] private string profileId = "";

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI percentageCompletedText;
    [SerializeField] private TextMeshProUGUI emblemCountText;

    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            percentageCompletedText.text = data.GetPercentageCompleted().ToString() + "%";
            emblemCountText.text = data.emblemCollected.ToString();
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }
}
