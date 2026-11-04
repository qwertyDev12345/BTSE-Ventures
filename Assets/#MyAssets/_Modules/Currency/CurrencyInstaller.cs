using UnityEngine;
using Zenject;

public class CurrencyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFromNew<Currency>();
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