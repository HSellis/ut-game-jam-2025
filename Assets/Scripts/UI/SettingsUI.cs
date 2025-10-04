using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider musicSlider; // set Min 0, Max 1

    void OnEnable()
    {
        if (AudioManager.Instance != null &&
            AudioManager.Instance.GetMusicVolume(out float v) >= 0f)
        {
            musicSlider.SetValueWithoutNotify(v);
        }

        musicSlider.onValueChanged.AddListener(OnMusicChanged);
    }

    void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(OnMusicChanged);
    }

    void OnMusicChanged(float v)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetMusicVolume(v);
    }
}