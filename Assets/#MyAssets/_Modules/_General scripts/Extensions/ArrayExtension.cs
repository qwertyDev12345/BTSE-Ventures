using System;

public static class ArrayExtension
{
    public static T Next<T>(this T[] array, T element)
    {
        var index = Array.IndexOf(array, element);
        index++;
        index %= array.Length;
        return array[index];
    }

    public static T Previous<T>(this T[] array, T element)
    {
        var index = Array.IndexOf(array, element);
        index--;

        if (index < 0)
        {
            index = array.Length - 1;
        }
        return array[index];
    }
}
