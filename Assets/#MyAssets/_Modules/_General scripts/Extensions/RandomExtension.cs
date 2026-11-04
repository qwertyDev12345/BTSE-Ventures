using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomExtension
{
    public static void CallbackWithChance(float chanceInPercent, System.Action callback)
    {
        if (TrueWithChance(chanceInPercent))
        {
            callback.Invoke();
        }
    }

    public static bool TrueWithChance(float chanceInPercent)
    {
        var rnd = Random.Range(0f, 1f);

        return rnd <= chanceInPercent / 100f;
    }

    public static T RandomElement<T>(Dictionary<T, float> chances)
    {
        var realChances = chances.ToDictionary(entry => entry.Key, entry => entry.Value);
        var realSum = 0f;
        foreach (var key in realChances.Keys)
        {
            realSum += realChances[key];
        }
        foreach (var key in chances.Keys)
        {
            realChances[key] /= realSum;
        }

        var rnd = Random.Range(0f, 1f);
        var chancesSum = 0f;

        foreach (var key in realChances.Keys)
        {
            chancesSum += realChances[key];

            if (chancesSum >= rnd)
            {
                return key;
            }
        }

        throw new System.Exception("RandomElement method exception");
    }

    public static List<T> Shuffle<T>(List<T> elements)
    {
        return elements.OrderBy(x => Random.Range(int.MinValue, int.MaxValue)).ToList();
    }

    public static List<T> PickNRandom<T>(List<T> elements, int num)
    {
        return Shuffle(elements).Take(num).ToList();
    }

    public static T PickRandom<T>(List<T> elements)
    {
        return elements[Random.Range(0, elements.Count)];
    }

    public static int RandomSign()
    {
        return Random.Range(0, 2) == 0 ? 1 : -1;
    }

    public static float Range(Vector2 fromTo)
    {
        return Random.Range(fromTo.x, fromTo.y);
    }

    public static Vector2 RandomVector()
    {
        return new Vector2(Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));
    }

    public static Vector2 RandomDirection()
    {
        return RandomVector().normalized;
    }
}
