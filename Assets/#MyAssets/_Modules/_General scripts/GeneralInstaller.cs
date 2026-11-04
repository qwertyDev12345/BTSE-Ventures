using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    [Header("General")]
    public ScenesController scenesController;
    public GameplaySettings gameplaySettings;

    public override void InstallBindings()
    {
        BindFromInstance(scenesController);
        BindFromInstance(gameplaySettings);
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