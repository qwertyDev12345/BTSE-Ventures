using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class TurnLeftRightByInputPanel : MonoBehaviour
{
    public bool reverce;
    int reverseSign;

    [Inject]
    InputPanel inputPanel;

    void Start()
    {
        reverseSign = reverce ? -1 : 1;


        inputPanel.pointerDown
            .Subscribe(pos =>
            {
                if (pos.x >= 0)
                {
                    transform.localScale = new Vector3(reverseSign * 1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(reverseSign * -1, 1, 1);
                }
            })
            .AddTo(this);
    }
}
