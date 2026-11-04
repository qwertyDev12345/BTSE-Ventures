using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class LeftRightMovementByInputPanel : MonoBehaviour
{
    Rigidbody2D rb;

    [Inject]
    InputPanel inputPanel;
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputPanel.pointerDown
            .Subscribe(pos =>
            {
                if (pos.x >= 0)
                {
                    //rb.velocity = Vector2.right * gameplaySettings.characterLeftRightSpeed;
                }
                else
                {
                    //rb.velocity = Vector2.left * gameplaySettings.characterLeftRightSpeed;
                }
            })
            .AddTo(this);

        inputPanel.pointerUp
            .Subscribe(pos =>
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            })
            .AddTo(this);
    }
}
