using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioMixer masterMixer; // assign in Inspector
    private AudioSource audioSource;
    const string MUSIC_PARAM = "MusicVol";

    public AudioResource mainMenuTheme;
    public AudioResource character1Theme;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject); // persists so slider works across scenes
    }

    // 0..1 from the slider
    public void SetMusicVolume(float linear01)
    {
        float v = Mathf.Clamp(linear01, 0.0001f, 1f);
        float dB = Mathf.Log10(v) * 20f; // convert linear to decibels
        masterMixer.SetFloat(MUSIC_PARAM, dB);
    }

    // Handy to sync the slider when opening the settings panel
    public float GetMusicVolume(out float linear01)
    {
        if (masterMixer.GetFloat(MUSIC_PARAM, out float dB))
        {
            linear01 = Mathf.Pow(10f, dB / 20f);
            return linear01;
        }
        linear01 = 1f;
        return linear01;
    }

    public void PlayCharacter1Theme()
    {
        audioSource.resource = character1Theme;
        audioSource.Play();
    }
}