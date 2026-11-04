using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopLocalInstaller : MonoInstaller
{
    public List<ShopOffer> offers;
    public LayoutGroup shopElementsLayout;
    public ShopElement shopElementPrefab;

    public override void InstallBindings()
    {
        BindFromNew<Disposer>();

        BindFromInstance(offers);
        BindFromInstance(shopElementsLayout);
        BindFromInstance(shopElementPrefab);
        BindFromNew<Shop>();

        foreach (var offer in offers)
        {
            Container.QueueForInject(offer);
        }

        Container.BindFactory<ShopOffer, ShopElement, ShopElement.Factory>().FromFactory<ShopElementFactory>();
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
