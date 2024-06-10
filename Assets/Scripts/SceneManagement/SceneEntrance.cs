using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEntrance : MonoBehaviour
{
    public string lastExitScene;
    public GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData.currentScenePoints = 0;
        Debug.Log("Last scene: " + PlayerPrefs.GetString("LastScene"));
        if (PlayerPrefs.GetString("LastScene") == lastExitScene)
        {
            PlayerScript.instance.transform.position = transform.position;
            Debug.Log("Player position: " + PlayerScript.instance.transform.position);
            Debug.Log("Entrance position: " + transform.position);
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
