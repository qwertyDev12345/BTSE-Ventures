using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ButtonSoundToggleSwitch : MonoBehaviour
{
    ToggleSwitch toggleSwitch;

    [Inject]
    AudioPlayer audioPlayer;

    void Start()
    {
        toggleSwitch = GetComponent<ToggleSwitch>();

        toggleSwitch.isOn.Value = audioPlayer.buttonSoundIsOn.Value;

        toggleSwitch.isOn.Subscribe(isOn =>
            {
                audioPlayer.buttonSoundIsOn.Value = isOn;
            })
            .AddTo(this);
    }
}
