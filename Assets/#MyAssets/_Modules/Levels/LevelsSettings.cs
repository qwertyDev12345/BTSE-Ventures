using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(LevelsSettings))]
public class LevelsSettings : ScriptableObject
{
    public int numberOfLevels;
}
