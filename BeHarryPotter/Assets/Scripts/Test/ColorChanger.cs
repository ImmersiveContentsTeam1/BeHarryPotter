using System;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void SetColor(Transform transform, Color color)
    {
        transform.GetComponent<Renderer>().material.color = color;
    }

    public void UpdateColor(string[] values)
    {
        var colorString = values[0];
        var shapeString = values[1];
        //Console.WriteLine(colorString);
        //Console.WriteLine(shapeString);

        if (ColorUtility.TryParseHtmlString(colorString, out var color))
        {
            if (!string.IsNullOrEmpty(shapeString))
            {
                var shape = transform.Find(shapeString);
                if (shape) SetColor(shape, color);
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    SetColor(transform.GetChild(i), color);
                }
            }
        }
    }
}