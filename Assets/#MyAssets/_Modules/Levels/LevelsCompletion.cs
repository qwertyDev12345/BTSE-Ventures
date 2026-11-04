using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelsCompletion
{
    Dictionary<int, bool> levelsCompletion;
    const string playerPrefsName = "levelsCompletion";

    LevelsSettings levelsSettings;

    public bool this[int level]
    {
        get 
        { 
            return levelsCompletion[level];
        }
        set 
        {
            levelsCompletion[level] = value;
            Save();
        }
    }

    public LevelsCompletion(LevelsSettings levelsSettings)
    {
        this.levelsSettings = levelsSettings;

        var defaultLevelsCompletion = new Dictionary<int, bool>();

        for (int i = 1; i <= levelsSettings.numberOfLevels; i++)
        {
            defaultLevelsCompletion.Add(i, false);
        }

        levelsCompletion = PlayerPrefsExtension.GetDictionary(playerPrefsName, defaultLevelsCompletion);
    }

    public int GetFirstUncompletedOrLastLevel()
    {
        for (int i = 1; i <= levelsSettings.numberOfLevels; i++)
        {
            if (!levelsCompletion[i])
            {
                return i;
            }
        }

        return levelsSettings.numberOfLevels;
    }

    void Save()
    {
        PlayerPrefsExtension.SetDictionary(playerPrefsName, levelsCompletion);
    }
}