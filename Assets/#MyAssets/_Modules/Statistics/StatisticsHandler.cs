using System;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class StatisticsHandler : IInitializable
{
    [Inject]
    Statistics statistics;
    [Inject]
    Disposer disposer;
    [Inject]
    GameEnder gameEnder;
    [Inject]
    LevelLauncher levelLauncher;

    public void Initialize()
    {
        Observable.NextFrame()
            .Subscribe(_ => SubscribeAll())
            .AddTo(disposer.disposables);
    }

    void SubscribeAll()
    {
        gameEnder.gameOver
            .Where(gameOver => gameOver)
            .Subscribe(_ => statistics.RoundsPlayed++)
            .AddTo(disposer.disposables);

        var pipes = levelLauncher.GetComponentsInChildren<Turn90DegreeOnPointerDown>();

        foreach (var pipe in pipes)
        {
            pipe.turned
                .Where(_ => _ > 0)
                .Subscribe(_ =>
                {
                    statistics.NumberOfRotates++;
                })
                .AddTo(disposer.disposables);
        }

        var basket = levelLauncher.GetComponentInChildren<Basket>();
        basket.numOfBalls
            .Where(_ => _ > 0)
            .Subscribe(_ => statistics.BallsDelivered++)
            .AddTo(disposer.disposables);
    }
}

