using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class MusicToggleSwitch : MonoBehaviour
{
    ToggleSwitch toggleSwitch;

    [Inject]
    AudioPlayer audioPlayer;

    void Start()
    {
        toggleSwitch = GetComponent<ToggleSwitch>();

        toggleSwitch.isOn.Value = audioPlayer.musicIsOn.Value;

        toggleSwitch.isOn.Subscribe(isOn =>
        {
            audioPlayer.musicIsOn.Value = isOn;
        })
            .AddTo(this);
    }
}
