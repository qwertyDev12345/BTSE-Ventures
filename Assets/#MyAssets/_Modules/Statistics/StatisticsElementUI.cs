using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatisticsElementUI : MonoBehaviour
{
    public StatisticsNames statisticsName;
    public Text text;

    [Inject]
    Statistics statistics;

    void Start()
    {
        text.text = statistics.GetStatisticsValueByName(statisticsName).ToString();
    }
}
