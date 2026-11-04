using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class MoveByDragWithOffset : MonoBehaviour
{
    public Vector2 xRestrictions;
    public Vector2 yRestrictions;

    Vector2 offset;
    Rigidbody2D rb;

    [Inject]
    InputPanel inputPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputPanel.dragStarted
            .Subscribe(pos =>
            {
                offset = rb.position - pos;
            })
            .AddTo(this);

        inputPanel.drag
            .Subscribe(pos =>
            {
                var realPos = pos + offset;
                var clampedX = Mathf.Clamp(realPos.x, xRestrictions.x, xRestrictions.y);
                var clampedY = Mathf.Clamp(realPos.y, yRestrictions.x, yRestrictions.y);
                realPos = new Vector2(clampedX, clampedY);

                rb.MovePosition(realPos);
            })
            .AddTo(this);
    }
}
