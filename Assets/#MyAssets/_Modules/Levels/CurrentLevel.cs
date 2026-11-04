using System;
using UniRx;
using Zenject;

public class CurrentLevel : ICount
{
    public ReactiveProperty<int> level = new();

    LevelsSettings levelsSettings;

    public CurrentLevel(LevelsCompletion levelsCompletion, LevelsSettings levelsSettings)
    {
        this.levelsSettings = levelsSettings;

        level.Value = levelsCompletion.GetFirstUncompletedOrLastLevel();
    }

    public void Next()
    {
        var nextLevel = level.Value++;

        if (nextLevel > levelsSettings.numberOfLevels)
        {
            level.Value = levelsSettings.numberOfLevels;
        }
    }

    public IObservable<int> AsObservable()
    {
        return level.AsObservable();
    }

    public int GetCurrentValue()
    {
        return level.Value;
    }
}
