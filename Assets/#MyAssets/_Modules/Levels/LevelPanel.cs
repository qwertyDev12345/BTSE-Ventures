using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelPanel : MonoBehaviour
{
    public int level;

    [Header("Internal")]
    public List<Button> clickableParts;

    [Inject]
    LevelsCompletion levelsCompletion;
    [Inject]
    CurrentLevel currentLevel;

    void Start()
    {
        UpdateView();
        SubscribeOnClickables();
    }

    void SubscribeOnClickables()
    {
        foreach (var clickable in clickableParts)
        {
            clickable.onClick.AddListener(() =>
            {
                currentLevel.level.Value = level;
            });
        }
    }

    void UpdateView()
    {
        foreach (var clickable in clickableParts)
        {
            if (levelsCompletion[level] || level == 1 || level == levelsCompletion.GetFirstUncompletedOrLastLevel())
            {
                clickable.interactable = true;
            }
            else
            {
                clickable.interactable = false;
            }
        }
    }
}
