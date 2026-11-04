using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Stick : MonoBehaviour, IPointerDownHandler
{
    [Inject]
    GameplaySettings gameplaySettings;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOComplete();
        transform.DOMoveX(gameplaySettings.stickMoveToPosX, gameplaySettings.stickMoveDuration)
            .SetLink(gameObject);
    }
}
