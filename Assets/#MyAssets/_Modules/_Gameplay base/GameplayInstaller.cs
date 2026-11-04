using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public LevelLauncher levelLauncher;
    public ScreenBordersCollider screenBordersCollider;

    [Header("General")]
    public ResultScreen resultScreen;
    public InputPanel inputPanel;
    public ScreenBorders screenBorders;

    public override void InstallBindings()
    {
        BindFromNew<Disposer>();
        BindFromInstance(resultScreen);
        BindFromInstance(inputPanel);
        BindFromNew<GameEnder>();
        BindFromInstance(screenBorders);
        BindScore();

        BindFromInstance(levelLauncher);
        BindFromNew<StatisticsHandler>();

        Container.Bind<ICount>().To<CurrentLevel>().FromResolve()
            .WhenInjectedInto<CurrentLevelUI>();

        BindFromInstance(screenBordersCollider);

        Time.timeScale = 1;
    }

    void BindScore()
    {
        BindFromNew<CurrentScore>();
        BindFromNew<BestScore>();
        Container.Bind<ICount>().To<CurrentScore>().FromResolve()
            .WhenInjectedInto<CurrentScoreUI>();
        Container.Bind<ICount>().To<BestScore>().FromResolve()
            .WhenInjectedInto<BestScoreUI>();
    }

    void BindFromNew<T>()
    {
        Container.BindInterfacesAndSelfTo<T>().FromNew().AsSingle().NonLazy();
    }

    void BindFromInstance<T>(T instance)
    {
        Container.BindInterfacesAndSelfTo<T>().FromInstance(instance);
    }
}