using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class InputPanel : MonoBehaviour
{
    public IObservable<Vector2> dragStarted;
    public IObservable<Vector2> drag;
    public IObservable<Vector2> dragEnded;
    public IObservable<Vector2> pointerDown;
    public IObservable<Vector2> pointerUp;

    void Awake()
    {
        var dragTrigger = gameObject.AddComponent<ObservableDragTrigger>();
        var dragStartedTrigger = gameObject.AddComponent<ObservableBeginDragTrigger>();
        var dragEndedTrigger = gameObject.AddComponent<ObservableEndDragTrigger>();
        var pointerDownTrigger = gameObject.AddComponent<ObservablePointerDownTrigger>();
        var pointerUpTrigger = gameObject.AddComponent<ObservablePointerUpTrigger>();

        drag = dragTrigger
            .OnDragAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        dragStarted = dragStartedTrigger
            .OnBeginDragAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        dragEnded = dragEndedTrigger
            .OnEndDragAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        pointerDown = pointerDownTrigger
            .OnPointerDownAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        pointerUp = pointerUpTrigger
            .OnPointerUpAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));
    }
}