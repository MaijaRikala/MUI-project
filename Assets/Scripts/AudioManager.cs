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

    private static bool musicStarted = false; // 🔥 KEY FIX

    void Awake()
    {
        Debug.Log("AudioManager Awake");

        if (instance != null)
        {
            Debug.Log("Duplicate destroyed");
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Optional: auto-assign if needed
        // musicSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (musicSlider != null) musicSlider.value = savedMusic;
        if (sfxSlider != null) sfxSlider.value = savedSfx;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSfx);

        // 🔥 START MUSIC ONLY ONCE
        if (!musicStarted)
        {
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
                musicStarted = true;
            }
        }
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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            sfxSource.Stop();
            Debug.Log("SFX manually stopped");
        }
    }
}