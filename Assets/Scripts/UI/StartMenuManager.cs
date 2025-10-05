using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject tutorialPanel;

    public AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayPressed()
    {
        audioManager.PlayCharacter1Theme();
        SceneManager.LoadScene("MainScene2");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }

    public void OnTutorialPressed()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void OnBackFromTutorial()
    {
        tutorialPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OnOpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnBackFromSettings()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
