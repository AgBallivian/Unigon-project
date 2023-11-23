using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject polygonPrefab;
    public int minSides = 1;
    public int maxSides = 2;

    
    //temporal Randomess (ADD PATTERNS NEXT UPDATE)a
    public float spawnDelay = 1f;
    public float shrinkSpeed = 0.7f;

    private float timer;
    private float globalTimer;

    private List<float> possibleAngles = new List<float>();

    void Start(){
        int polygonSides = polygonPrefab.GetComponent<PolygonSideGenerator>().sides;

        int sides = Random.Range(minSides, maxSides + 1);
        float angleStep = 360f / polygonSides; // Use 'sides' instead of 'polygonSides'

        // Create a list of possible angles to spawn the polygon
        
        for (int i = 0; i < polygonSides; i++) // Use 'sides' instead of 'polygonSides'
        {
            possibleAngles.Add(angleStep * i);
        }
    }

    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if(timer >= spawnDelay){
            SpawnObjects();
            timer = 0;
        }
    }

    private void SpawnObjects()
    {
        int sides = Random.Range(minSides, maxSides + 1);
        // Choose a random angle from the list
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];

        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle);

        Debug.Log(spawnAngle);

        Vector3 spawnPosition = new Vector3(0f, -3f, 0f);

        GameObject spawnedPolygon = Instantiate(polygonPrefab, spawnPosition, spawnRotation);
        spawnedPolygon.GetComponent<PolygonSideGenerator>().sidesToCreate = sides;
        spawnedPolygon.GetComponent<PolygonController>().shrinkSpeed = shrinkSpeed;
    }

}
