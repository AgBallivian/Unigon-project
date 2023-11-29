using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPolygon : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] polygonPoints;
    public int[] polygonTriangles;

    public bool isFilled;
    public int sides;
    public float radius;
    public float centerRadius;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;

    void OnDrawGizmos(){
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
        if(isFilled)
        {
            drawFilled(sides, radius);
        }
        else
        {
            drawHollow(sides, radius, centerRadius);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        if (isFilled)
        {
            drawFilled(sides, radius);
        }
        else
        {
            drawHollow(sides, radius, centerRadius);
        }
    }

    void drawFilled(int sides, float radius)
    {
        polygonPoints = GetCircumferencePoints(sides, radius).ToArray();
        polygonTriangles = DrawFilledTriangles(polygonPoints);
        mesh.Clear();
        mesh.vertices = polygonPoints;
        mesh.triangles = polygonTriangles;

        Color[] colors = new Color[polygonPoints.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = (i % 3 == 0) ? color1 : color2;
        }

        mesh.colors = colors;
    }

    void drawHollow(int sides, float outerRadius, float innerRadius)
    {
        List<Vector3> pointsList = new List<Vector3>();
        List<Vector3> outerPoints = GetCircumferencePoints(sides, outerRadius);
        pointsList.AddRange(outerPoints);
        List<Vector3> innerPoints = GetCircumferencePoints(sides, innerRadius);
        pointsList.AddRange(innerPoints);

        polygonPoints = pointsList.ToArray();

        polygonTriangles = DrawHollowTriangles(polygonPoints);
        mesh.Clear();
        mesh.vertices = polygonPoints;
        mesh.triangles = polygonTriangles;

        Color[] colors = new Color[polygonPoints.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = (i % 3 == 0) ? color1 : color2;
        }

        mesh.colors = colors;
    }

    int[] DrawHollowTriangles(Vector3[] points)
    {
        int sides = points.Length / 2;
        int triangleAmount = sides * 2;

        List<int> newTriangles = new List<int>();
        for (int i = 0; i < sides; i++)
        {
            int outerIndex = i;
            int innerIndex = i + sides;

            // first triangle starting at outer edge i
            newTriangles.Add(outerIndex);
            newTriangles.Add(innerIndex);
            newTriangles.Add((i + 1) % sides);

            // second triangle starting at outer edge i
            newTriangles.Add(outerIndex);
            newTriangles.Add(sides + ((sides + i - 1) % sides));
            newTriangles.Add(outerIndex + sides);
        }
        return newTriangles.ToArray();
    }

    List<Vector3> GetCircumferencePoints(int sides, float radius)
    {
        List<Vector3> points = new List<Vector3>();
        float circumferenceProgressPerStep = (float)1 / sides;
        float TAU = 2 * Mathf.PI;
        float radianProgressPerStep = circumferenceProgressPerStep * TAU;

        for (int i = 0; i < sides; i++)
        {
            float currentRadian = radianProgressPerStep * i;
            points.Add(new Vector3(Mathf.Cos(currentRadian) * radius, Mathf.Sin(currentRadian) * radius, 0));
        }
        return points;
    }

    int[] DrawFilledTriangles(Vector3[] points)
    {
        int triangleAmount = points.Length - 2;
        List<int> newTriangles = new List<int>();
        for (int i = 0; i < triangleAmount; i++)
        {
            newTriangles.Add(0);
            newTriangles.Add(i + 2);
            newTriangles.Add(i + 1);
        }
        return newTriangles.ToArray();
    }
}
//Thanks to this tutorial: https://www.youtube.com/watch?v=YG-gIX_OvSE&ab_channel=ZeroKelvinTutorials
