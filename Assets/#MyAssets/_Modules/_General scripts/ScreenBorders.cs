using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    Vector3[] corners = new Vector3[4];

    public Vector2 GetXRestrictions(float offset = 0)
    {
        GetComponent<RectTransform>().GetWorldCorners(corners);
        return new Vector2(corners[0].x + offset, corners[2].x - offset);
    }

    public Vector2 GetYRestrictions(float offset = 0)
    {
        GetComponent<RectTransform>().GetWorldCorners(corners);
        return new Vector2(corners[0].y + offset, corners[2].y - offset);
    }

    public Vector2 GetRandomPointOnBorder(float offset = 0)
    {
        GetComponent<RectTransform>().GetWorldCorners(corners);
        var randomCorner = corners[Random.Range(0, corners.Length)];
        var adjCorner = corners.Next(randomCorner);

        randomCorner -= new Vector3(Mathf.Sign(randomCorner.x) * offset, Mathf.Sign(randomCorner.y) * offset);
        adjCorner -= new Vector3(Mathf.Sign(adjCorner.x) * offset, Mathf.Sign(adjCorner.y) * offset);

        return Vector2.Lerp(randomCorner, adjCorner, Random.Range(0f, 1f));
    }

    public bool IsInBorders(Vector2 point)
    {
        var xRes = GetXRestrictions();
        var yRes = GetYRestrictions();

        if (point.x >= xRes.x && point.x <= xRes.y &&
            point.y >= yRes.x && point.y <= yRes.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2 GetRandomPointInBorders()
    {
        var xRes = GetXRestrictions();
        var yRes = GetYRestrictions();

        var point = new Vector2(Random.Range(xRes.x, xRes.y), Random.Range(yRes.x, yRes.y));
        return point;
    }
    
    public float GetRandomXInBorders(float offset = 0)
    {
        var xRes = GetXRestrictions(offset);

        return Random.Range(xRes.x, xRes.y);
    }
}