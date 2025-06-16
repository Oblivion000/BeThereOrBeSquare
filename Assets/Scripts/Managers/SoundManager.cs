using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource; // Optional: For sound effects, if needed

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;

    protected override void Awake()
    {
        base.Awake(); // Ensures Singleton behavior

        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.loop = false; // SFX typically do not loop
            sfxSource.playOnAwake = false; // Prevents SFX from playing on start
        }

        musicSource.loop = true;
        musicSource.playOnAwake = false;

        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // Default to 1 if not set
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // Default to 1 if not set

        SetMusicVolume(savedMusicVolume);
        SetSFXVolume(savedSFXVolume);

        PlayMusic();
    }


    public void PlayMusic()
    {
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume); // Save the volume setting
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume); // Save the volume setting
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}

