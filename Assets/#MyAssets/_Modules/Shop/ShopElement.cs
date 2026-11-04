using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class ShopElement : MonoBehaviour
{
    public TMP_Text price;
    public Image image;
    public Button button;
    public GameObject selectedCheck;
    public Button decorativeButton;
    public GameObject currencyImage;

    [Inject]
    Disposer disposer;
    [Inject]
    Skins skins;
    [Inject]
    Shop shop;

    public void Construct(ShopOffer offer)
    {
        decorativeButton.interactable = offer.EnoughCurrencyToBuy();
        button.interactable = offer.Purchased || offer.EnoughCurrencyToBuy();

        currencyImage.SetActive(!offer.Purchased);
        decorativeButton.gameObject.SetActive(!offer.Purchased);
        price.gameObject.SetActive(!offer.Purchased);
        selectedCheck.SetActive(skins.CurrentSkin == offer.sprite);

        price.text = offer.price.ToString();
        image.sprite = offer.sprite;

        button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (!offer.Purchased)
                {
                    offer.MakePurchase();
                }

                skins.CurrentSkin = offer.sprite;
                shop.UpdateOffers();
            })
            .AddTo(disposer.disposables);
    }

    public class Factory : PlaceholderFactory<ShopOffer, ShopElement>
    {
    }
}


public class ShopElementFactory : IFactory<ShopOffer, ShopElement>
{
    readonly DiContainer _container;

    [Inject]
    ShopElement shopElementPrefab;

    public ShopElementFactory(DiContainer container)
    {
        _container = container;
    }

    public ShopElement Create(ShopOffer offer)
    {
        var shopElement = _container.InstantiatePrefabForComponent<ShopElement>(shopElementPrefab);
        shopElement.Construct(offer);
        return shopElement;
    }
}
