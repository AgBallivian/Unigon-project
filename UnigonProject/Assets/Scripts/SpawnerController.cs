using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject polygonPrefab;
    public int minSides = 3;
    public int maxSides = 5;
    
    //temporal Randomess (ADD PATTERNS NEXT UPDATE)
    public float SpawnDelay = 1f;
    
    private float timer;
    private float globalTimer;

    void Update(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if(timer >= SpawnDelay){
            SpawnObjects();
            timer = 0;
        }
    }

    private void SpawnObjects(){
        int polygonSides = polygonPrefab.GetComponent<PolygonSideGenerator>().sides;

        int sides = Random.Range(minSides, maxSides + 1);
        float angleStep = 360f / polygonSides;

        // Create a list of possible angles to spawn the polygon
        List<float> possibleAngles = new List<float>();
        for (int i = 0; i < polygonSides; i++)
        {
            possibleAngles.Add(angleStep * i);
        }

        // Choose a random angle from the list
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];

        // Rotate around z axis
        // Vector3 spawnAngleV = new Vector3(0f, 0f, spawnAngle);
        // Quaternion spawnAngleQ = Quaternion.Euler(spawnAngleV);

        // Debug.Log(spawnAngleQ);

        Vector3 spawnPosition = new Vector3(0f, -3f, 0f);

        GameObject spawnedPolygon = Instantiate(polygonPrefab, spawnPosition, Quaternion.identity);
        spawnedPolygon.transform.RotateAround(spawnPosition, Vector3.forward, spawnAngle);
        spawnedPolygon.GetComponent<PolygonSideGenerator>().sidesToCreate = sides;
    }

}
