using UnityEngine;
using Zenject;

public class SkinsInstaller : MonoInstaller
{
    public Skins skins;

    public override void InstallBindings()
    {
        BindFromInstance(skins);
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