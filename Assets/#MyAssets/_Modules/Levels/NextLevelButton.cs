using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [Inject]
    CurrentLevel currentLevel;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { currentLevel.Next(); });
    }
}
