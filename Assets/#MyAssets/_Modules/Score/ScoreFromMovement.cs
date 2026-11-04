using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ScoreFromMovement : MonoBehaviour
{
    Vector3 prevPos;
    Vector3 curPos;

    [Inject]
    CurrentScore score;
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        curPos = transform.position;

        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                prevPos = curPos;
                curPos = transform.position;

                var distance = Vector3.Distance(prevPos, curPos);
                //score.AddToScore(distance * gameplaySettings.movementToScoreMultiplyer);
            })
            .AddTo(this);
    }
}
