//using OPS.Obfuscator.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//[DoNotObfuscateClass]
[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(ShopOffer))]
public class ShopOffer : ScriptableObject
{
    public Sprite sprite;
    public int price;

    const string playerPrefsName = "ShopOffer___";

    [Inject]
    Currency currency;
    
    public bool Purchased
    {
        get
        {
            return PlayerPrefsExtension.GetBool(playerPrefsName + sprite.name, false);
        }
        private set
        {
            PlayerPrefsExtension.SetBool(playerPrefsName + sprite.name, value);
        }
    }

    public bool EnoughCurrencyToBuy()
    {
        return currency.Num.Value >= price;
    }

    public void MakePurchase()
    {
        currency.Num.Value -= price;
        Purchased = true;
    }
}
