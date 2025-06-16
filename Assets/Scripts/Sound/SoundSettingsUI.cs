using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundSettingsUI : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    [SerializeField] Toggle muteMusicToggle;
    [SerializeField] Toggle muteSFXToggle;

    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    private float previousMusicVolume = 1f;
    private float previousSFXVolume = 1f;

    void Start()
    {
        // Initialize sliders from SoundManager
        float currentMusicVolume = SoundManager.Instance.musicSource.volume;
        float currentSFXVolume = SoundManager.Instance.sfxSource.volume;

        musicVolumeSlider.value = currentMusicVolume;
        sfxVolumeSlider.value = currentSFXVolume;

        // Hook up listeners
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        muteMusicToggle.isOn = false;
        muteMusicToggle.onValueChanged.AddListener(OnMusicMuteToggled);

        muteSFXToggle.isOn = false;
        muteSFXToggle.onValueChanged.AddListener(OnSFXMuteToggled);
    }

    void OnMusicVolumeChanged(float value)
    {
        if (!isMusicMuted)
        {
            SoundManager.Instance.SetMusicVolume(value);
        }
    }

    void OnSFXVolumeChanged(float value)
    {
        if (!isSFXMuted)
        {
            SoundManager.Instance.SetSFXVolume(value);
        }
    }

    void OnMusicMuteToggled(bool muted)
    {
        isMusicMuted = muted;

        if (muted)
        {
            previousMusicVolume = SoundManager.Instance.musicSource.volume;
            SoundManager.Instance.SetMusicVolume(0f);
        }
        else
        {
            SoundManager.Instance.SetMusicVolume(previousMusicVolume);
            musicVolumeSlider.value = previousMusicVolume;
        }
    }

    void OnSFXMuteToggled(bool muted)
    {
        isSFXMuted = muted;

        if (muted)
        {
            previousSFXVolume = SoundManager.Instance.sfxSource.volume;
            SoundManager.Instance.SetSFXVolume(0f);
        }
        else
        {
            SoundManager.Instance.SetSFXVolume(previousSFXVolume);
            sfxVolumeSlider.value = previousSFXVolume;
        }
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu"); // Adjust to match your main menu scene
    }
}

