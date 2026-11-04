using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public enum TogglePlayerPrefsNames
{
    unset,
    sound,
    music
}

public class ToggleSwitch : MonoBehaviour
{
    public ReactiveProperty<bool> isOn = new();

    public TogglePlayerPrefsNames playerPrefsName;
    public bool defaultState;

    public Button button;
    public Image stateImage;

    [Header("Visual")]
    public Sprite isOnSprite;
    public Sprite isOffSprite;
    

    void Awake()
    {
        UpdateSpriteWhenStateChanged();
        ChangeStateOnButtonClick();
    }

    void ChangeStateOnButtonClick()
    {
        button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                isOn.Value = !isOn.Value;
            })
            .AddTo(this);
    }

    void UpdateSpriteWhenStateChanged()
    {
        isOn.Subscribe(isOn =>
        {
            if (isOn)
            {
                stateImage.sprite = isOnSprite;
            }
            else
            {
                stateImage.sprite = isOffSprite;
            }
        })
        .AddTo(this);
    }
}
