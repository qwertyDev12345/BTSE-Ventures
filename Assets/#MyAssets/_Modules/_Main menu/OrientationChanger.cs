using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OrientationChanger : MonoBehaviour
{
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        if (Screen.orientation != gameplaySettings.screenOrientation)
        {
            Screen.orientation = gameplaySettings.screenOrientation;
        }
    }
}
