using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class PrivacyPolicyButton : MonoBehaviour
{
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => 
        { 
            Application.OpenURL(gameplaySettings.privacyPolicyLink); 
        });
    }
}
