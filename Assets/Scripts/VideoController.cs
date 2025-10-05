using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanelController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject buttonsContainer;

    void Start()
    {
        // Hide buttons at start
        buttonsContainer.SetActive(false);

        // Subscribe to end event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Start playing automatically
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Stop the video and show the buttons
        buttonsContainer.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}