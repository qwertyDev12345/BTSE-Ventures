using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelCurrencyObjectsUI : MonoBehaviour
{
    [Inject]
    LevelCurrencyObjects levelCurrencyObjects;

    void Start()
    {
        GetComponentInChildren<TMP_Text>().text = $@"{levelCurrencyObjects.GetNumOfPicked()}";
    }
}
