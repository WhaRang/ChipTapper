using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public Sound.SoundType sliderSoundType;

    private void Start()
    {
        if (sliderSoundType == Sound.SoundType.EFFECT)
        {
            slider.value = AudioSettings.settings.GetEffectsVolume();
        }
        else if (sliderSoundType == Sound.SoundType.MUSIC)
        {
            slider.value = AudioSettings.settings.GetMusicVolume();
        }
        else
        {
            slider.value = AudioSettings.settings.GetVolume();
        }
    }

    public void SetMasterVolume()
    {
        AudioManager.manager.SetVolume(slider.value);
    }

    public void SetEffectsVolume()
    {
        AudioManager.manager.SetEffectsVolume(slider.value);
    }

    public void SetMusicVolume()
    {
        AudioManager.manager.SetMusicVolume(slider.value);
    }
}
