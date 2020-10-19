using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings settings;

    const float DEFAULT_VOLUME = 1.0f;

    float volume;
    float effectsVolume;
    float musicVolume;

    private void Awake()
    {
        if (settings == null)
            settings = this.gameObject.GetComponent<AudioSettings>();

        DontDestroyOnLoad(gameObject);

        volume = PlayerPrefs.GetFloat("volume", DEFAULT_VOLUME);
        effectsVolume = PlayerPrefs.GetFloat("effectsVolume", DEFAULT_VOLUME);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", DEFAULT_VOLUME);
    }

    public float GetVolume()
    {
        return volume;
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
    }

    public float GetEffectsVolume()
    {
        return effectsVolume;
    }

    public void SetEffectsVolume(float newEffectsVolume)
    {
        effectsVolume = newEffectsVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }

    private void OnDestroy()
    {
        SaveAllVolumes();   
        PlayerPrefs.Save();
    }

    void SaveAllVolumes()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("effectsVolume", effectsVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
}
