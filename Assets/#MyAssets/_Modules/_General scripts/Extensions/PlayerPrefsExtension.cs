using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public static class PlayerPrefsExtension
{
    public static bool GetBool(string key, bool defaultValue)
    {
        var result = PlayerPrefs.GetInt(key, -1);

        if (result == 1)
        {
            return true;
        }
        else if (result == 0)
        {
            return false;
        }
        else
        {
            return defaultValue;
        }
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static TimeSpan GetTimeSpan(string key, TimeSpan defaultValue)
    {
        var result = PlayerPrefs.GetString(key, string.Empty);

        if (result == string.Empty)
        {
            return defaultValue;
        }
        else
        {
            return TimeSpan.FromMilliseconds(double.Parse(result));
        }
    }

    public static void SetTimeSpan(string key, TimeSpan value)
    {
        PlayerPrefs.SetString(key, value.TotalMilliseconds.ToString());
    }

    public static Dictionary<T1, T2> GetDictionary<T1, T2>(string key, Dictionary<T1, T2> defaultValue)
    {
        var json = PlayerPrefs.GetString(key, string.Empty);

        if (json == string.Empty)
        {
            return defaultValue;
        }
        else
        {
            return JsonConvert.DeserializeObject<Dictionary<T1, T2>>(json);
        }
    }

    public static void SetDictionary<T1, T2>(string key, Dictionary<T1, T2> value)
    {
        var json = JsonConvert.SerializeObject(value, Formatting.Indented);
        PlayerPrefs.SetString(key, json);
    }
}
