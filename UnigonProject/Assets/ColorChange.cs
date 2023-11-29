using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public DrawPolygon drawPolygon; 
    public List<ColorPair> colorPairs; 
    public float timeBetweenColorChanges = 2f; 

    private int currentColorIndex = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenColorChanges)
        {
            ChangeColors();
            timer = 0f;
        }
    }

    void ChangeColors()
    {
        if (drawPolygon != null && colorPairs.Count > 0)
        {
            drawPolygon.SetColors(colorPairs[currentColorIndex].color1, colorPairs[currentColorIndex].color2);
            currentColorIndex = (currentColorIndex + 1) % colorPairs.Count;
        }
    }
}

[System.Serializable]
public class ColorPair
{
    public Color color1;
    public Color color2;
}
