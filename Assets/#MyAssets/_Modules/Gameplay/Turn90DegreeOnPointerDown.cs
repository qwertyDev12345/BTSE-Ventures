using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Turn90DegreeOnPointerDown : MonoBehaviour, IPointerDownHandler
{
    public ReactiveProperty<int> turned = new ReactiveProperty<int>(0);

    public bool Clockwise;

    [Inject]
    GameplaySettings gameplaySettings;

    public void OnPointerDown(PointerEventData eventData)
    {
        var degree = (Clockwise ? -1 : 1) * 90;

        transform.DOComplete();
        transform.DORotate(new Vector3(0, 0, degree), gameplaySettings.tubeRotationDuration, RotateMode.LocalAxisAdd)
            .SetLink(gameObject);

        turned.Value++;
    }
}
