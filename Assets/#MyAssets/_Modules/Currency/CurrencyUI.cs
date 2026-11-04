using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class CurrencyUI : MonoBehaviour
{
    public string format = "{0}";

    TMP_Text text;

    [Inject]
    Currency currency;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();

        currency.Num
            .StartWith()
            .Subscribe(num =>
            {
                text.text = string.Format(format, num);
            })
            .AddTo(this);
    }
}
