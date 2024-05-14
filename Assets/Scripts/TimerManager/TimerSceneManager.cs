using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSceneManager : MonoBehaviour
{
   void Start()
    {
        // Check if TimerManager.instance is not null before subscribing to events
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp += RestartScene; // Subscribe to the onTimeUp event
        }
        else
        {
            Debug.LogError("TimerManager instance is null.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp -= RestartScene; // Unsubscribe from the onTimeUp event
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
    }
}
