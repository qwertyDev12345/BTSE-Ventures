using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatisticsNames
{
    RoundsPlayed,
    NumberOfRotates,
    BallsDelivered,
}

public class Statistics
{
    public int RoundsPlayed
    {
        get => PlayerPrefs.GetInt(nameof(RoundsPlayed), 0);
        set => PlayerPrefs.SetInt(nameof(RoundsPlayed), value);
    }

    public int NumberOfRotates
    {
        get => PlayerPrefs.GetInt(nameof(NumberOfRotates), 0);
        set => PlayerPrefs.SetInt(nameof(NumberOfRotates), value);
    }

    public int BallsDelivered
    {
        get => PlayerPrefs.GetInt(nameof(BallsDelivered), 0);
        set => PlayerPrefs.SetInt(nameof(BallsDelivered), value);
    }

    public int GetStatisticsValueByName(StatisticsNames name)
    {
        return name switch
        {
            StatisticsNames.RoundsPlayed => RoundsPlayed,
            StatisticsNames.NumberOfRotates => NumberOfRotates,
            StatisticsNames.BallsDelivered => BallsDelivered,
            _ => 0
        };
    }
}
