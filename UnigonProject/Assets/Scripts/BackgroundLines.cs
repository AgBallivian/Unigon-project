using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLines : MonoBehaviour
{
    public int sides = 3;
    public float radius = 1f;
    public float lineLengthMultiplier = 10f;
    public float lineWidth = 0.1f;
    public LineRenderer lineRenderer;

    void OnDrawGizmos()
    {
        DrawLines();
    }
    void Start()
    {
        DrawLines();
    }

    void DrawLines()
    {
        lineRenderer.positionCount = sides * 2; 

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        
        for (int currentPoint = 0; currentPoint < sides; currentPoint++)
        {
            float angle = (360f / sides) * currentPoint;

            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            Vector3 direction = new Vector3(x, y, 0f).normalized;

            Vector3 lineEndPoint = transform.position + direction * lineLengthMultiplier;

            lineRenderer.SetPosition(currentPoint * 2, transform.position); 
            lineRenderer.SetPosition(currentPoint * 2 + 1, lineEndPoint);   
        }
    }
}
