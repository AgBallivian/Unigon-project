using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorLvL2 : MonoBehaviour
{
    private float phase1Time = 15.0f;
    private float phase2Time = 20.0f;
    private float phase3Time = 40.0f;
    private float phase4Time = 65.0f;
    private float phase5Time = 77.0f;
    [SerializeField] float colorChangeSpeed = 0.005f;
    public float hue = 0.5f;
    public bool goingUp = true;
    void Start(){
    }
    void FixedUpdate(){
        if (Time.timeSinceLevelLoad < phase1Time){
            phase1();
        }
        else if (Time.timeSinceLevelLoad < phase2Time){
            phase2();
        }
        else if (Time.timeSinceLevelLoad < phase3Time){
            phase3();
        }
        else if (Time.timeSinceLevelLoad < phase4Time){
            phase4();
        }
        else{
            phase5();
        }

    }
    
    void phase1(){
        
        //Make Hue go from the values of Blue to cyan
        //Blue = 0.6666667f
        //Cyan = 0.5f
        if (goingUp){
            if (hue > 0.6666667f){
                goingUp = false;
            }
            else{
                hue += colorChangeSpeed;
            }
        }
        else{
            if (hue < 0.5f){
                goingUp = true;
            }
            else{
                hue -= colorChangeSpeed;
            }
        }
        
        //Hue / Saturation / Value
        Color newColor = Color.HSVToRGB(hue, 0.6f, 0.5f);

        // Apply the new color to the SpriteRenderer
        GetComponent<SpriteRenderer>().color = newColor;
    }
    void phase2(){
        //Make Hue go from the values of red and orange
        //orange = 0.08333333f
        //red = 0.0f
        if (goingUp){
            if (hue > 0.08333333f){
                goingUp = false;
            }
            else{
                hue += colorChangeSpeed;
            }
        }
        else{
            if (hue < 0.0f){
                goingUp = true;
            }
            else{
                hue -= colorChangeSpeed;
            }
        }
        Color newColor = Color.HSVToRGB(hue, 0.6f, 0.5f);
        GetComponent<SpriteRenderer>().color = newColor;
    }
    void phase3(){
        if (goingUp){
            if (hue > 0.2f){
                goingUp = false;
            }
            else{
                hue += colorChangeSpeed;
            }
        }
        else{
            if (hue < 0.08333333f){
                goingUp = true;
            }
            else{
                hue -= colorChangeSpeed;
            }
        }
        Color newColor = Color.HSVToRGB(hue, 0.6f, 0.6f);
        GetComponent<SpriteRenderer>().color = newColor;
    }
    void phase4(){
        //Make Hue go from the values of purple and pink
        //purple = 0.8333333f
        //pink = 0.9166667f
        if (goingUp){
            if (hue > 0.9166667f){
                goingUp = false;
            }
            else{
                hue += colorChangeSpeed;
            }
        }
        else{
            if (hue < 0.8333333f){
                goingUp = true;
            }
            else{
                hue -= colorChangeSpeed;
            }
        }
        Color newColor = Color.HSVToRGB(hue, hue, hue);
        GetComponent<SpriteRenderer>().color = newColor;
    }
    void phase5(){
        //Make Hue go from the values of all the colors
        if (goingUp){
            if (hue > 1.0f){
                goingUp = false;
            }
            else{
                hue += colorChangeSpeed*4;
            }
        }
        else{
            if (hue < 0.0f){
                goingUp = true;
            }
            else{
                hue -= colorChangeSpeed*4;
            }
        }
        Color newColor = Color.HSVToRGB(hue, 0.9f, 0.8f);
        GetComponent<SpriteRenderer>().color = newColor;
    }
}