//using OPS.Obfuscator.Attribute;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    MainMenu,
    Gameplay,
    Statistics,
    Skins,
    Rules,
    Levels,
    Achievements,
    Shop,
    RecipeView
}

//[DoNotObfuscateClass]
[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(ScenesController))]
public class ScenesController : SerializedScriptableObject
{
    public Dictionary<Scenes, string> scenes;

    public void LoadScene(Scenes name)
    {
        SceneManager.LoadScene(scenes[name]);
    }
}
