using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSceneManager : MonoBehaviour
{
    public GameObject restartModal;
    private PlayerController playerController;

    void Start()
    {
        // Check if TimerManager.instance is not null before subscribing to events
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp += showRestartModal; // Subscribe to the onTimeUp event
        }
        else
        {
            Debug.LogError("TimerManager instance is null.");
        }

        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp -= showRestartModal; // Unsubscribe from the onTimeUp event
        }
    }

    void showRestartModal()
    {
        if (playerController != null)
        {
            playerController.FreezePlayer(); // Freeze the player
        }

        restartModal.gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        playerController.canMove = true; // Allow the player to move again
    }
}
