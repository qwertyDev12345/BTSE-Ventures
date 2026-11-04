using System.Collections;
using System.Collections.Generic;
using UniRx;
using Zenject;
using UnityEngine;

public class Currency
{
    public ReactiveProperty<int> Num = new();

    string currencyName;

    public Currency()
    {
        currencyName = "Main currency";
        Num.Value = PlayerPrefs.GetInt(currencyName, 0);
        Num.Subscribe(num => { PlayerPrefs.SetInt(currencyName, num); });
    }
}
