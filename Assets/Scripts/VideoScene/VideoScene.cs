using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoScene : MonoBehaviour
{
    public string nextScene;

    public VideoPlayer videoPlayer;
   private bool isPaused = false;

    public void OnNextClicked()
    {
       SceneManager.LoadScene(nextScene);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            videoPlayer.Play();
            isPaused = false;
        }
        else
        {
            videoPlayer.Pause();
            isPaused = true;
        }
    }

    public void ReplayVideo()
    {
        videoPlayer.Stop();
        videoPlayer.time = 0;
        videoPlayer.Play();
        isPaused = false;
    }
}
