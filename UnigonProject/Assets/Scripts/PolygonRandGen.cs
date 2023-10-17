using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class PolygonSideGenerator : MonoBehaviour
{
    public int sides = 6; 
    public int sidesToCreate = 5; 
    public float radius = 1f;
    public float sideWidth = 0.2f;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    private Vector3 originalScale;

    void OnDrawGizmos(){
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        DrawPolygonSides();
        SetEdgeCollider(lineRenderer);

    }

    void Start(){
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        DrawPolygonSides();
    }

    void Update(){

        DrawPolygonSides(); 
        SetEdgeCollider(lineRenderer);
    }
    

    void DrawPolygonSides(){
        // Scale
        float scaledRadius = radius * Mathf.Max(transform.localScale.x, transform.localScale.y);
        float scaledSideWidth = sideWidth * Mathf.Max(transform.localScale.x, transform.localScale.y);

        // Rotation
        float rotationAngle = transform.rotation.eulerAngles.z; // Get the current rotation angle in degrees

        // edgeCollider.edgeRadius = scaledSideWidth / 2f;

        Vector3[] lineRendererPositions = new Vector3[sidesToCreate * 2]; // Two points for each side
        // Vector2[] colliderPoints = new Vector2[sidesToCreate * 2]; // Two points for each side

        for (int currentSide = 0; currentSide < sidesToCreate; currentSide++)
        {
            float startRad = ((float)currentSide / (float)sides) * (Mathf.PI * 2);
            float endRad = ((float)(currentSide + 1) / (float)sides) * (Mathf.PI * 2);
            
            float startX = Mathf.Cos(startRad + rotationAngle * Mathf.Deg2Rad) * scaledRadius;
            float startY = Mathf.Sin(startRad + rotationAngle * Mathf.Deg2Rad) * scaledRadius;

            float endX = Mathf.Cos(endRad + rotationAngle * Mathf.Deg2Rad) * scaledRadius;
            float endY = Mathf.Sin(endRad + rotationAngle * Mathf.Deg2Rad) * scaledRadius;

            lineRendererPositions[currentSide * 2] = new Vector3(startX, startY, 0f);
            lineRendererPositions[currentSide * 2 + 1] = new Vector3(endX, endY, 0f);

            // colliderPoints[currentSide * 2] = transform.TransformPoint(new Vector2(startX, startY));
            // colliderPoints[currentSide * 2 + 1] = transform.TransformPoint(new Vector2(endX, endY));
        }

        // Set the positions for the LineRenderer
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = sidesToCreate * 2;
        lineRenderer.SetPositions(lineRendererPositions);
        lineRenderer.startWidth = sideWidth;
        lineRenderer.endWidth = sideWidth;

    }
    void SetEdgeCollider(LineRenderer lineRenderer){
        List<Vector2> edges = new List<Vector2>();
        for(int point = 0; point<lineRenderer.positionCount; point++){
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        edgeCollider.points = edges.ToArray();
    }
}

