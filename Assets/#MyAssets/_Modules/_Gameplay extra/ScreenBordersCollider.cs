using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScreenBordersCollider : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;

    [Inject]
    ScreenBorders screenBorders;

    void Start()
    {
        var xRestrictions = screenBorders.GetXRestrictions();
        var yRestrictions = screenBorders.GetYRestrictions();
        left.transform.position = new Vector3(xRestrictions.x, 0);
        right.transform.position = new Vector3(xRestrictions.y, 0);
        bottom.transform.position = new Vector3(0, yRestrictions.x);
        top.transform.position = new Vector3(0, yRestrictions.y);
    }
}
