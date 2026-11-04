using System.Collections.Generic;
using Zenject;

public class LevelsGrades : IInitializable
{
    Dictionary<int, int> levelsGrades;
    const string playerPrefsName = "levelsGrades";

    [Inject]
    LevelsSettings levelsSettings;

    public int this[int level]
    {
        get
        {
            return levelsGrades[level];
        }
        set
        {
            levelsGrades[level] = value;
            Save();
        }
    }

    public void Initialize()
    {
        var defaultLevelsGrades = new Dictionary<int, int>();

        for (int i = 1; i <= levelsSettings.numberOfLevels; i++)
        {
            defaultLevelsGrades.Add(i, 0);
        }

        levelsGrades = PlayerPrefsExtension.GetDictionary(playerPrefsName, defaultLevelsGrades);
    }

    void Save()
    {
        PlayerPrefsExtension.SetDictionary(playerPrefsName, levelsGrades);
    }
}
