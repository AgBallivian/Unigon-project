using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class PolygonSideGenerator : MonoBehaviour
{
    public int sides = 6; 
    public int sidesToCreate = 4; 
    public float radius = 1f;
    public float sideWidth = 0.2f;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    void OnDrawGizmos()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        DrawPolygonSides();
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        DrawPolygonSides();
    }

    void DrawPolygonSides()
    {
        edgeCollider.edgeRadius = sideWidth / 2f;

        float scaledRadius = radius * Mathf.Max(transform.localScale.x, transform.localScale.y);
        float scaledSideWidth = sideWidth * Mathf.Max(transform.localScale.x, transform.localScale.y);

        Vector3[] lineRendererPositions = new Vector3[sidesToCreate * 2]; // Two points for each side
        Vector2[] colliderPoints = new Vector2[sidesToCreate * 2]; // Two points for each side

        for (int currentSide = 0; currentSide < sidesToCreate; currentSide++)
        {
            float startRad = ((float)currentSide / (float)sides) * (Mathf.PI * 2);
            float endRad = ((float)(currentSide + 1) / (float)sides) * (Mathf.PI * 2);

            float startX = Mathf.Cos(startRad) * radius;
            float startY = Mathf.Sin(startRad) * radius;

            float endX = Mathf.Cos(endRad) * radius;
            float endY = Mathf.Sin(endRad) * radius;

            lineRendererPositions[currentSide * 2] = new Vector3(startX, startY - 3, 0f);
            lineRendererPositions[currentSide * 2 + 1] = new Vector3(endX, endY - 3, 0f);

            colliderPoints[currentSide * 2] = new Vector2(startX, startY - 3);
            colliderPoints[currentSide * 2 + 1] = new Vector2(endX, endY - 3);
        }

        // Set the positions for the LineRenderer
        lineRenderer.positionCount = sidesToCreate * 2;
        lineRenderer.SetPositions(lineRendererPositions);
        lineRenderer.startWidth = scaledSideWidth;
        lineRenderer.endWidth = scaledSideWidth;

        // Set the points for the EdgeCollider
        edgeCollider.points = colliderPoints;
    }
}

