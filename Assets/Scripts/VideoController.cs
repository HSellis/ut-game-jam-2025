using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPanelController : MonoBehaviour
{
    [Header("Ending Panels")]
    public GameObject goodEndingPanel;
    public GameObject neutralEndingPanel;
    public GameObject badEndingPanel;

    private VideoPlayer activeVideoPlayer;
    private GameObject activeButtonsContainer;

    void Start()
    {
        // Hide all buttons initially
        HideAllButtons();

        // Find which panel is active in the scene
        if (goodEndingPanel.activeSelf)
            SetupPanel(goodEndingPanel);
        else if (neutralEndingPanel.activeSelf)
            SetupPanel(neutralEndingPanel);
        else if (badEndingPanel.activeSelf)
            SetupPanel(badEndingPanel);
        else
            Debug.LogWarning("No ending panel is active!");
    }

    void SetupPanel(GameObject panel)
    {
        // Get references inside this panel
        activeVideoPlayer = panel.GetComponentInChildren<VideoPlayer>(true);
        activeButtonsContainer = panel.transform.Find("ButtonsContainer").gameObject;

        if (activeVideoPlayer == null)
        {
            Debug.LogError("No VideoPlayer found in the active panel!");
            return;
        }

        // Hide the buttons first
        activeButtonsContainer.SetActive(false);

        // Subscribe to the end event
        activeVideoPlayer.loopPointReached += OnVideoEnd;

        // Start the video
        activeVideoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Show only this panel's buttons when video ends
        if (activeButtonsContainer != null)
            activeButtonsContainer.SetActive(true);
    }

    void HideAllButtons()
    {
        if (goodEndingPanel != null)
            goodEndingPanel.transform.Find("ButtonsContainer").gameObject.SetActive(false);
        if (neutralEndingPanel != null)
            neutralEndingPanel.transform.Find("ButtonsContainer").gameObject.SetActive(false);
        if (badEndingPanel != null)
            badEndingPanel.transform.Find("ButtonsContainer").gameObject.SetActive(false);
    }

    // Called by your button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}