using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Shop : IInitializable
{
    [Inject]
    List<ShopOffer> offers;
    [Inject]
    LayoutGroup shopElementsLayout;
    [Inject]
    ShopElement.Factory shopElementFactory;
    [Inject]
    Skins skins;

    public void Initialize()
    {
        var defaultSkinOffer = offers.Find(offer => offer.sprite == skins.defaultSkin);
        
        if (!defaultSkinOffer.Purchased)
        {
            defaultSkinOffer.MakePurchase();
        }

        UpdateOffers();
    }

    public void UpdateOffers()
    {
        Clear();

        foreach (var offer in offers)
        {
            var shopElement = shopElementFactory.Create(offer);

            var scale = shopElement.transform.localScale;

            shopElement.transform.SetParent(shopElementsLayout.transform);
            shopElement.transform.localScale = scale;
        }
    }

    void Clear()
    {
        foreach (Transform shopElement in shopElementsLayout.transform)
        {
            GameObject.Destroy(shopElement.gameObject);
        }
    }
}
