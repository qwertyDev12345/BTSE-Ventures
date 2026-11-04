using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangingFloat
{
    ChangingFloatParams parameters;

    public float CurrentValue 
    { 
        get
        {
            return currentValue;
        }
        private set
        {
            currentValue = value;
        }
    }
    float currentValue;

    public float TimeInterval
    {
        get => parameters.timeInterval;
    }

    public ChangingFloat(ChangingFloatParams parameters)
    {
        this.parameters = parameters;

        currentValue = parameters.startValue;

        if (parameters.changeAmount < 0)
        {
            parameters.maxValue = currentValue;
        }
        else if (parameters.changeAmount > 0)
        {
            parameters.minValue = currentValue;
        }
    }

    public void Next()
    {
        CurrentValue += parameters.changeAmount;

        if (CurrentValue < parameters.minValue)
        {
            CurrentValue = parameters.minValue;
        }
        if (CurrentValue > parameters.maxValue)
        {
            CurrentValue = parameters.maxValue;
        }
    }
}
