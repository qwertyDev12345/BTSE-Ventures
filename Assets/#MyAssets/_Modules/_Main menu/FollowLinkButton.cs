using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FollowLinkButton : MonoBehaviour
{
    public string link;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.OpenURL(link);
        });
    }
}
