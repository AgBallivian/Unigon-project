using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColors : MonoBehaviour
{
    [SerializeField] float phase1Time = 14.0f;
    [SerializeField] float phase2Time = 28.0f;
    [SerializeField] float phase3Time = 50.0f;
    [SerializeField] float phase4Time = 78.0f;
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
        hue/=2;
        //Hue / Saturation / Value
        Color newColor = Color.HSVToRGB(hue, 0.6f, 0.4f);

        // Apply the new color to the SpriteRenderer
        GetComponent<LineRenderer>().material.color = newColor;
    }
    void phase2(){

    }
    void phase3(){

    }
    void phase4(){

    }
    void phase5(){

    }
}
