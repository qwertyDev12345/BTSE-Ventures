using Zenject;

public class LevelsInstaller : MonoInstaller
{
    public LevelsSettings levelsSettings;

    public override void InstallBindings()
    {
        BindFromInstance(levelsSettings);
        BindFromNew<LevelsCompletion>();
        BindFromNew<LevelsGrades>();
        BindCurrentLevel();
    }

    void BindCurrentLevel()
    {
        BindFromNew<CurrentLevel>();
        Container.Bind<ICount>().To<CurrentLevel>().FromResolve()
            .WhenInjectedInto<CurrentLevelUI>();
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