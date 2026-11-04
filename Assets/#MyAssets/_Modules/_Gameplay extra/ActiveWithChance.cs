using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWithChance : MonoBehaviour
{
    public float chance = 100;

    void Start()
    {
        gameObject.SetActive(RandomExtension.TrueWithChance(chance));
    }
}
