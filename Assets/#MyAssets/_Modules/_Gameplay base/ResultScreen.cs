using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ResultScreen : MonoBehaviour
{
    [Inject]
    GameplaySettings gameplaySettings;

    public void Show()
    {
        Observable.Timer(TimeSpan.FromSeconds(gameplaySettings.winScreenDelay))
            .Subscribe(_ => 
            { 
                gameObject.SetActive(true);
                Time.timeScale = gameplaySettings.stopTimeOnWinScreen ? 0 : 1;
            })
            .AddTo(this);
    }
}
