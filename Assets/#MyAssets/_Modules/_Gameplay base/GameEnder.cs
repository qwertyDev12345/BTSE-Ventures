using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class GameEnder : IInitializable
{
    public ReactiveProperty<bool> gameOver = new();

    [Inject]
    ResultScreen resultScreen;
    [Inject]
    ScenesController scenesController;
    [Inject]
    LevelsCompletion levelsCompletion;
    [Inject]
    Disposer disposer;
    [Inject]
    GameplaySettings gameplaySettings;
    [Inject]
    CurrentLevel currentLevel;
    [Inject]
    Currency currency;
    [Inject]
    ScreenBordersCollider screenBordersCollider;

    public void Initialize()
    {
        screenBordersCollider.OnTriggerEnter2DAsObservable()
            .Where(_ => _.attachedRigidbody.CompareTag("Player"))
            .Subscribe(_ => Lose())
            .AddTo(disposer.disposables);
    }

    public void Win()
    {
        if (!gameOver.Value)
        {
            gameOver.Value = true;

            levelsCompletion[currentLevel.level.Value] = true;
            currency.Num.Value += 100;

            resultScreen.Show();
        }
    }

    public void Lose()
    {
        if (!gameOver.Value)
        {
            gameOver.Value = true;

            Observable.Timer(TimeSpan.FromSeconds(gameplaySettings.loseReloadDelay))
                .Subscribe(_ =>
                {
                    scenesController.LoadScene(Scenes.Gameplay);
                })
                .AddTo(disposer.disposables);
        }
    }
}
