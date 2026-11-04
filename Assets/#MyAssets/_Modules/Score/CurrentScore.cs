using System;
using UniRx;
using UnityEngine;

public class CurrentScore : ICount
{
    public ReactiveProperty<float> curScore = new(0);

    public IObservable<int> AsObservable()
    {
        return curScore.Select(score => (int)score);
    }

    public int GetCurrentValue()
    {
        return (int)curScore.Value;
    }
}
