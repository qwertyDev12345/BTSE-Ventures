using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSpriteColliderFixer : MonoBehaviour
{
    void Start()
    {
        FixCollider();
    }

    [Button]
    void FixCollider()
    {
        var collider = GetComponent<BoxCollider2D>();
        var sr = GetComponent<SpriteRenderer>();

        collider.size = new Vector2(transform.localScale.x * sr.size.x, transform.localScale.y * sr.size.y);
    }
}
