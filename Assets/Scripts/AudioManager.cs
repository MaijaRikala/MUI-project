using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioMixer audioMixer;

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip revealSound;

    private bool revealPlayedThisFrame = false;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (musicSlider != null)
            musicSlider.value = savedMusic;

        if (sfxSlider != null)
            sfxSlider.value = savedSfx;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSfx);

        StartMusic();

    }

    public void SetMusicVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20;
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20;
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void PlayWinSound()
    {
        if (winSound != null)
            sfxSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        if (loseSound != null)
            sfxSource.PlayOneShot(loseSound);
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        // Prevent multiple reveal sounds in same frame
        if (clip == revealSound)
        {
            if (revealPlayedThisFrame) return;

            revealPlayedThisFrame = true;
        }

        sfxSource.PlayOneShot(clip);
    }

    void Update()
    {
        revealPlayedThisFrame = false;
    }

    public void RegisterSliders(Slider music, Slider sfx)
    {
        musicSlider = music;
        sfxSlider = sfx;

        if (musicSlider != null)
        {
            musicSlider.onValueChanged.RemoveAllListeners(); // important
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.RemoveAllListeners(); // important
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    public void StartMusic()
{
    if (musicSource != null && !musicSource.isPlaying)
    {
        musicSource.Play();
    }
}
}