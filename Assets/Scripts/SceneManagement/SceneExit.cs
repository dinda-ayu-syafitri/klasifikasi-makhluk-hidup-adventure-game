using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string lastExitScene;

    public PointsText points;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name != "1 - Lobby")
        {
            Debug.Log("Current Scene Point" + points.currentScenePoints);

            if (points.currentScenePoints >= 700)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    PlayerPrefs.SetString("LastScene", lastExitScene);
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerPrefs.SetString("LastScene", lastExitScene);
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }
}
