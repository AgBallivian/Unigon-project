using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLv1 : MonoBehaviour
{
    public GameObject polygonPrefab;
    private float patternchangeTime = 5.0f;

    //temporal Randomess (ADD PATTERNS NEXT UPDATE)
    // public float spawnDelay = 1f;
    public float shrinkSpeed = 0.7f;

    private float timer;
    private float globalTimer;

    private List<float> possibleAngles = new List<float>();
    public int polygonSides = 6;

    void Start(){
        //Create Posible angles to spawn the polygon (Regular Polygon)
        int polygonSides = polygonPrefab.GetComponent<PolygonSideGenerator>().sides;
        float angleStep = 360f / polygonSides; 
        for (int i = 0; i < polygonSides; i++)
        {
            possibleAngles.Add(angleStep * i);
        }
    }

    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if(timer >= patternchangeTime){
            StartCoroutine(Pattern3C());
            timer = 0;
        }

    }
    
    //Create Global patterns, so angles will be according to their position on the list
        // Choose a random angle from the list
        // int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        // float spawnAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        // Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle);
    //Patter 3-C
    private IEnumerator Pattern3C()
    {
        // Choose a random angle from the list
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle);

        //Spawn wall 1 of 3
        SpawnWall(polygonSides - 1, spawnRotation);
        yield return new WaitForSeconds(1.0f);
        //Spawn wall 2 of 3
        Quaternion spawnRotation2 = Quaternion.Euler(0f, 0f, spawnAngle + 90f);
        SpawnWall(polygonSides - 1, spawnRotation2);
        yield return new WaitForSeconds(1.0f);
        //Spawn wall 3 of 3
        Quaternion spawnRotation3 = Quaternion.Euler(0f, 0f, spawnAngle);
        SpawnWall(polygonSides - 1, spawnRotation3);

    }

    //Spawn the wall function 
    private void SpawnWall(int sides, Quaternion spawnRotation)
    {
        Debug.Log("Angle of spawn: " + spawnRotation.eulerAngles.z);
        Vector3 spawnPosition = new Vector3(0f, -3f, 0f);
        GameObject spawnedPolygon = Instantiate(polygonPrefab, spawnPosition, spawnRotation);
        spawnedPolygon.GetComponent<PolygonSideGenerator>().sidesToCreate = sides;
        spawnedPolygon.GetComponent<PolygonController>().shrinkSpeed = shrinkSpeed;

    }
}
