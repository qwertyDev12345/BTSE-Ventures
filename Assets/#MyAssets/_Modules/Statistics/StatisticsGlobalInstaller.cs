using UnityEngine;
using Zenject;

public class StatisticsGlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFromNew<Statistics>();
    }

    void BindFromNew<T>()
    {
        Container.BindInterfacesAndSelfTo<T>().FromNew().AsSingle().NonLazy();
    }
}