using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class CountDisplayer : MonoBehaviour
{
    [OnValueChanged(nameof(UpdateEditorText))]
    public string format;
    public bool withAnimation;
    [ShowIf(nameof(withAnimation))]
    public float animationDuration;


    protected TMP_Text text;
    protected int lastSetNum;
    protected Tween tween;

    [Inject]
    protected ICount count;

    protected void Start()
    {
        text = GetComponentInChildren<TMP_Text>();

        count.AsObservable()
            .StartWith(count.GetCurrentValue())
            .Subscribe(num =>
            {
                if (withAnimation)
                {
                    SetTextWithAnimation(num);
                }
                else
                {
                    SetText(num);
                }
            })
            .AddTo(this);
    }

    protected void SetTextWithAnimation(int scoreNum)
    {
        tween?.Complete();

        tween = DOTween.To(
                        () => lastSetNum,
                        x => {
                            SetText(x);
                        },
                        scoreNum, animationDuration)
            .SetLink(gameObject);
    }

    protected void SetText(int scoreNum)
    {
        text.text = string.Format(format, scoreNum);
        lastSetNum = scoreNum;
    }

    protected void UpdateEditorText()
    {
        GetComponentInChildren<TMP_Text>().text =
            format.Replace("{", "")
            .Replace("}", "");
    }
}
