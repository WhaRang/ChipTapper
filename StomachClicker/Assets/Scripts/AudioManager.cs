using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager manager;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float effectsVolume;

    [Range(0f, 1f)]
    public float musicVolume;

    float prevVolume;

    bool isMuted;

    private void Awake()
    {

        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        volume = AudioSettings.settings.GetVolume();
        effectsVolume = AudioSettings.settings.GetEffectsVolume();
        musicVolume = AudioSettings.settings.GetMusicVolume();

        UpdateSoundsVolume();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        float additiveVolumeSettings = 1.0f;

        if (s.type == Sound.SoundType.EFFECT)
        {
            additiveVolumeSettings = effectsVolume;
        }

        if (s.type == Sound.SoundType.MUSIC)
        {
            additiveVolumeSettings = musicVolume;
        }

        if (s == null)
        {
            return;
        }
        if (!(s.source.isPlaying && s.single))
        {
            s.source.volume = s.volume * volume * additiveVolumeSettings;
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        if (!(s.source.isPlaying && s.single))
        {
            s.source.Stop();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        AudioSettings.settings.SetVolume(newVolume);
        UpdateSoundsVolume();
    }

    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
        AudioSettings.settings.SetMusicVolume(newMusicVolume);
        UpdateSoundsVolume();
    }

    public void SetEffectsVolume(float newEffectsVolume)
    {
        effectsVolume = newEffectsVolume;
        AudioSettings.settings.SetEffectsVolume(newEffectsVolume);
        UpdateSoundsVolume();
    }

    void UpdateSoundsVolume()
    {
        foreach (Sound s in sounds) {
            float additiveVolumeSttings = 1.0f;

            if (s.type == Sound.SoundType.EFFECT)
            {
                additiveVolumeSttings = effectsVolume;
            }

            if (s.type == Sound.SoundType.MUSIC)
            {
                additiveVolumeSttings = musicVolume;
            }

            s.source.volume = s.volume * volume * additiveVolumeSttings;
        }
    }

    public void MuteAll()
    {
        prevVolume = volume;
        volume = 0.0f;
    }

    public void UnmuteAll()
    {
        volume = prevVolume;
    }
}
