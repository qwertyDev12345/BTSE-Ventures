using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GradeInStars2Sprite : MonoBehaviour, IGradeInStars
{
    public List<Image> stars;

    public Sprite emptyStarSprite;
    public Sprite starSprite;

    public void SetGrade(int numOfStars)
    {
        Clear();

        if (numOfStars >= 1)
        {
            stars[0].sprite = starSprite;
        }

        if (numOfStars >= 2)
        {
            stars[1].sprite = starSprite;
        }

        if (numOfStars >= 3)
        {
            stars[2].sprite = starSprite;
        }
    }

    void Clear()
    {
        foreach (var star in stars)
        {
            star.sprite = emptyStarSprite;
        }
    }
}
