using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject settingsPanel;

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
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
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
