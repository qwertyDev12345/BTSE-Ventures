using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float musicVolume;
    [Range(0.0f, 1.0f)]
    public float buttonClickVolume;

    public ReactiveProperty<bool> buttonSoundIsOn = new();
    public ReactiveProperty<bool> musicIsOn = new();

    public AudioSource musicAS;
    public AudioSource buttonClickAS;

    const string buttonSoundPlayerPrefsName = "buttonSound";
    const string musicPlayerPrefsName = "music";

    void Awake()
    {
        Load();
        DontDestroyOnLoad(gameObject);

        SaveWhenChanged();

        musicIsOn.Subscribe(isOn =>
        {
            if (isOn)
            {
                musicAS.volume = musicVolume;
            }
            else
            {
                musicAS.volume = 0;
            }
        })
        .AddTo(this);

        buttonSoundIsOn.Subscribe(isOn =>
        {
            if (isOn)
            {
                buttonClickAS.volume = buttonClickVolume;
            }
            else
            {
                buttonClickAS.volume = 0;
            }
        })
        .AddTo(this);

        PlayMusic();
    }

    public void PlayClickOnButtonSound()
    {
        buttonClickAS.Play();
    }

    public void PlayMusic()
    {
        musicAS.Play();
    }

    void SaveWhenChanged()
    {
        buttonSoundIsOn.Subscribe(isOn =>
        {
            PlayerPrefsExtension.SetBool(buttonSoundPlayerPrefsName, isOn);
        })
        .AddTo(this);

        musicIsOn.Subscribe(isOn =>
        {
            PlayerPrefsExtension.SetBool(musicPlayerPrefsName, isOn);
        })
        .AddTo(this);
    }

    void Load()
    {
        buttonSoundIsOn.Value = PlayerPrefsExtension.GetBool(buttonSoundPlayerPrefsName, true);
        musicIsOn.Value = PlayerPrefsExtension.GetBool(musicPlayerPrefsName, true);
    }
}
