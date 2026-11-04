using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class LevelCurrencyObjects : IInitializable
{
    public ReactiveCollection<CurrencyObject> currencyObjectsLeft = new();

    public int StartAwailableCurrencyNum { get; private set; }

    [Inject]
    Disposer disposer;

    public void Initialize()
    {
        Observable.NextFrame()
            .Subscribe(_ => StartAwailableCurrencyNum = currencyObjectsLeft.Count)
            .AddTo(disposer.disposables);
    }

    public int GetGrade()
    {
        if (currencyObjectsLeft.Count == 0)
        {
            return 3;
        }
        else if ((float)GetNumOfPicked() / (float)StartAwailableCurrencyNum > 0.5f)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public int GetNumOfPicked()
    {
        return StartAwailableCurrencyNum - currencyObjectsLeft.Count;
    }
}
