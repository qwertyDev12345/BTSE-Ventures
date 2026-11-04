using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Basket : MonoBehaviour
{
    public ReactiveProperty<int> numOfBalls = new(0);

    [Inject]
    GameplaySettings gameplaySettings;
    [Inject]
    GameEnder gameEnder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        numOfBalls.Value++;

        if (numOfBalls.Value == gameplaySettings.numOfBallsInGame)
        {
            gameEnder.Win();
        }
    }
}
