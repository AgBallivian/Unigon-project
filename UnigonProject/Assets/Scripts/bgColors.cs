using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgColors : MonoBehaviour
{
    [SerializeField] float rainbowFullCycle = 10.0f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= startTime)
        {
            float t = (Time.time - startTime) / rainbowFullCycle;
            t = t - Mathf.Floor(t); 
            float hue = t;
            //Hue / Saturation / Value
            Color newColor = Color.HSVToRGB(hue, 0.6f, 0.4f);

            // Apply the new color to the SpriteRenderer
            GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}
