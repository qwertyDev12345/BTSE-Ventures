using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonSound : MonoBehaviour
{
    [Inject]
    AudioPlayer audioPlayer;

    void Awake()
    {
        GetComponent<Button>().OnPointerDownAsObservable()
            .Subscribe(_ =>
            {
                audioPlayer.PlayClickOnButtonSound();
            })
            .AddTo(this);
    }
}
