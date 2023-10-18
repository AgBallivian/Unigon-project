using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoligonGenerator : MonoBehaviour
{
    public int sides = 3;
    public float radius = 1f;
    public LineRenderer polygonRenderer;
    public float width = 0.5f;

    void OnDrawGizmos(){
        polygonRenderer = GetComponent<LineRenderer>();
        DrawLooped();
    }

    void Start()
    {
        polygonRenderer = GetComponent<LineRenderer>();
        DrawLooped();
    }   

    void Update()
    {
        DrawLooped();   
    }

    void DrawLooped(){
        polygonRenderer.positionCount = sides;
        float TAU = Mathf.PI * 2;
        polygonRenderer.startWidth = width;
        polygonRenderer.endWidth = width;
        float scaledRadius = radius * Mathf.Max(transform.localScale.x, transform.localScale.y);

        for(int currentPoint = 0; currentPoint<sides; currentPoint++){
            float currentRad = ((float)currentPoint / (float)sides) * TAU;
            float x = Mathf.Cos(currentRad) * scaledRadius;
            float y = Mathf.Sin(currentRad) * scaledRadius;
            polygonRenderer.SetPosition(currentPoint, new Vector3(x,y,0f));
        }
        //Close the polygon
        polygonRenderer.useWorldSpace = false;
        polygonRenderer.loop = true;
    }
    //https://www.youtube.com/watch?v=cRulHmoiabA

    // void DrawLoopedv2(){
    //     //Update the size all the time
    //     float scaledRadius = radius * Mathf.Max(transform.localScale.x, transform.localScale.y);
    //     Vector3[] polygonRendererPositions = new Vector3[sides * 2];

    //     for (int currentSide = 0; currentSide < sides; currentSide++){
    //         float startRad = ((float)currentSide / (float)sides) * (Mathf.PI * 2);
    //         float endRad = ((float)(currentSide + 1) / (float)sides) * (Mathf.PI * 2);

    //         float startX = Mathf.Cos(startRad  * Mathf.Deg2Rad) * scaledRadius;
    //         float startY = Mathf.Sin(startRad  * Mathf.Deg2Rad) * scaledRadius;

    //         float endX = Mathf.Cos(endRad * Mathf.Deg2Rad) * scaledRadius;
    //         float endY = Mathf.Sin(endRad * Mathf.Deg2Rad) * scaledRadius;

    //         polygonRendererPositions[currentSide * 2] = new Vector3(startX, startY, 0f);
    //         polygonRendererPositions[currentSide * 2 + 1] = new Vector3(endX, endY, 0f);
    //     }
    //     polygonRenderer.useWorldSpace = false;
    //     polygonRenderer.positionCount = sides * 2;
    //     polygonRenderer.SetPositions(polygonRendererPositions);
    //     polygonRenderer.startWidth = width;
    //     polygonRenderer.endWidth = width;
    //     polygonRenderer.loop = true;
    // }
}
