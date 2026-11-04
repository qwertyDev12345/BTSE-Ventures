using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundChanger : MonoBehaviour
{
    [Inject]
    Skins skins;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skins.CurrentSkin;
    }
}
