using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GradeInStars1Sprite : MonoBehaviour, IGradeInStars
{
    public List<Image> stars;

    public void SetGrade(int numOfStars)
    {
        Clear();

        if (numOfStars >= 1)
        {
            stars[0].gameObject.SetActive(true);
        }

        if (numOfStars >= 2)
        {
            stars[1].gameObject.SetActive(true);
        }

        if (numOfStars >= 3)
        {
            stars[2].gameObject.SetActive(true);
        }
    }

    void Clear()
    {
        foreach (var star in stars)
        {
            star.gameObject.SetActive(false);
        }
    }
}
