using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CurrencyObject : MonoBehaviour
{
    bool collected;

    [Inject]
    Currency currency;
    [Inject]
    LevelCurrencyObjects levelCurrencyObjects;

    void Start()
    {
        levelCurrencyObjects.currencyObjectsLeft.Add(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            currency.Num.Value += 1;

            levelCurrencyObjects.currencyObjectsLeft.Remove(this);
            collected = true;
            Destroy(gameObject);
        }
    }
}
