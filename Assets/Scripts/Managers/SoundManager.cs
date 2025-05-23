using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Audio Sources")]
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;

    protected override void Awake()
    {
        base.Awake(); // Ensures Singleton behavior

        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        musicSource.loop = true;
        musicSource.playOnAwake = false;
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

    public void SetVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }
}

