using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class BestScore : IInitializable, ICount
{
    ReactiveProperty<float> bestScore = new();

    [Inject]
    CurrentScore currentScore;
    [Inject]
    Disposer disposer;

    public void Initialize()
    {
        Load();
        StartSavingWhenUpdated();
        StartCheckingForUpdate();
    }

    void Load()
    {
        bestScore.Value = PlayerPrefs.GetFloat(nameof(BestScore), 0);
    }

    void StartSavingWhenUpdated()
    {
        bestScore.Subscribe(bestScore =>
        {
            PlayerPrefs.SetFloat(nameof(BestScore), bestScore);
        })
        .AddTo(disposer.disposables);
    }

    void StartCheckingForUpdate()
    {
        currentScore.curScore
            .Where(curScore => curScore > bestScore.Value)
            .Subscribe(
            curScore =>
            {
                bestScore.Value = curScore;
            })
            .AddTo(disposer.disposables);
    }

    public IObservable<int> AsObservable()
    {
        return bestScore.Select(score => (int)score);
    }

    public int GetCurrentValue()
    {
        return (int)bestScore.Value;
    }
}
