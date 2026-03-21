using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        AudioManager.instance.RegisterSliders(musicSlider, sfxSlider);
    }
}