using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

public class CyclicPointToPointMovement : MonoBehaviour
{
    public Vector2 point1;
    public Vector2 point2;
    public ChangingFloat pointToPointMoveDuration;
    public Ease ease = Ease.Linear;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = point1;

        Observable.EveryLateUpdate()
            .Where(_ => rb.position == point1 || rb.position == point2)
            .Subscribe(_ =>
            {
                MoveToOtherSide();
            })
            .AddTo(this);
    }

    void MoveToOtherSide()
    {
        rb.DOKill();

        if (rb.position == point1)
        {
            rb.DOMove(point2, pointToPointMoveDuration.CurrentValue)
                .SetEase(ease)
                .SetLink(gameObject);
        }
        else if (rb.position == point2)
        {
            rb.DOMove(point1, pointToPointMoveDuration.CurrentValue)
                .SetEase(ease)
                .SetLink(gameObject);
        }
    }
}
