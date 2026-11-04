using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelLauncher : MonoBehaviour
{
    public List<GameObject> levels;

    [Inject]
    CurrentLevel currentLevel;

    void Awake()
    {
        TurnOnLevel();
    }

    void TurnOnLevel()
    {
        levels[currentLevel.level.Value - 1].SetActive(true);
    }
}
