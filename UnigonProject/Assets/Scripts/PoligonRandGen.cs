using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoligonRandGen : MonoBehaviour
{
    public int sides = 3;
    public float radius = 1f;
    public LineRenderer polygonRenderer;
    public float width = 0.5f;

    void OnDrawGizmos(){
        DrawLooped();
    }

    void Start()
    {
        DrawLooped();
    }   

    void DrawLooped(){
        polygonRenderer.positionCount = sides;
        float TAU = Mathf.PI * 2;
        polygonRenderer.startWidth = width;
        polygonRenderer.endWidth = width;

        for(int currentPoint = 0; currentPoint<sides; currentPoint++){
            float currentRad = ((float)currentPoint / (float)sides) * TAU;
            float x = Mathf.Cos(currentRad) * radius;
            float y = Mathf.Sin(currentRad) * radius;
            polygonRenderer.SetPosition(currentPoint, new Vector3(x,y-3,0f));
        }
        
        //Close the polygon
        polygonRenderer.loop = true;
    }
    //https://www.youtube.com/watch?v=cRulHmoiabA
}
