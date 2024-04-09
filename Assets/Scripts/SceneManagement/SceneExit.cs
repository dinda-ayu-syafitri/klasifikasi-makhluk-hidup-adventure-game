using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string lastExitScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            PlayerPrefs.SetString("LastScene", lastExitScene);
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}
