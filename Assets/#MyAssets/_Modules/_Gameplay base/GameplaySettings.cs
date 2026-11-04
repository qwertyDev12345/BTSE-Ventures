using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(GameplaySettings))]
public class GameplaySettings : SerializedScriptableObject
{
    public float tubeRotationDuration;
    public float stickMoveToPosX;
    public float stickMoveDuration;
    public float numOfBallsInGame;

    [Header("General")]
    public ScreenOrientation screenOrientation = ScreenOrientation.Portrait;
    public float winScreenDelay;
    public bool stopTimeOnWinScreen;
    public float loseReloadDelay;

    [HideInInspector]
    public string privacyPolicyLink;
}