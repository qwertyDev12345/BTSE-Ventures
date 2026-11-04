using Sirenix.OdinInspector;
using System;

[Serializable]
public class ChangingFloatParams
{
    public float startValue;
    public float changeAmount;

    [ShowIf("@changeAmount < 0")]
    public float minValue;
    [ShowIf("@changeAmount > 0")]
    public float maxValue;

    [ToggleLeft]
    public bool changingWithTime;

    [ShowIf("@changingWithTime")]
    public float timeInterval;
}
