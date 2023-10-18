using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    Camera cam;
    
    void Start(){
        cam = GetComponent<Camera>();
    }
    void FixedUpdate(){
        UpdateColors();
    }
    
    public void UpdateColors(){
        //Change colors in multiple phases 
        //Phase 1: Shades of Blue
        //This is until 14 seconds
        if (Time.timeSinceLevelLoad < 14f){
            phase1();
        }

    }
    void phase1(){
        //Phase 1: Shades of Blue
        //This is until 14 seconds
        while (Time.timeSinceLevelLoad < 14f){
            //Gradient from dark Blue to light Blue
            float t = (Time.timeSinceLevelLoad) / 14f;
            t = t - Mathf.Floor(t);
            float hue = t;
            Color newColor = Color.HSVToRGB(hue, 0.6f, 0.4f);
            cam.backgroundColor = newColor;

        }

    }
}