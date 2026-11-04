using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(Skins))]
public class Skins : SerializedScriptableObject
{
    public List<Sprite> skins;
    public Sprite defaultSkin;

    public Sprite CurrentSkin
    {
        get
        {
            var curSkinName = PlayerPrefs.GetString("CurrentSkin", defaultSkin.name);
            return skins.Find(skin => skin.name == curSkinName);
        }
        set
        {
            PlayerPrefs.SetString("CurrentSkin", value.name);
        }
    }
}
