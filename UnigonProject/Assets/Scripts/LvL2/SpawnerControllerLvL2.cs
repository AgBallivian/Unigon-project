using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControllerLvL2 : MonoBehaviour
{
    public GameObject polygonPrefab;
    public int minSides = 4;
    public int maxSides = 4;

    
    //temporal Randomess (ADD PATTERNS NEXT UPDATE)
    public float spawnDelay = 1f;
    public float shrinkSpeed = 0.7f;

    //Phase Timers
    private float phasechangeTime = 2.0f;
    private float phase1Time = 5.0f;
    private float phase2Time = 20.0f;
    private float phase3Time = 50.0f;
    private float phase4Time = 60.0f;
    private float phase5Time = 75.0f;

    private float timer;
    private float globalTimer;

    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;
        //Phase 2
        if (globalTimer >= phase1Time && globalTimer < phase2Time){
            Debug.Log("Phase 2 " + globalTimer);
            minSides = 2;
            maxSides = 2;
            spawnDelay = 0.32f;
        }
        //delay in between phase
        else if (globalTimer >= phase2Time && globalTimer < phase2Time + phasechangeTime){
            Debug.Log("Phase 2 delay " + globalTimer);
            spawnDelay = 100f;
        }
        //Phase 3
        else if (globalTimer >= phase2Time && globalTimer < phase3Time){
            Debug.Log("Phase 3" + globalTimer);
            minSides = 1;
            maxSides = 6;
            spawnDelay = 0.6f;
            shrinkSpeed = 1.1f;
        }
        //Delay in between phases
        else if (globalTimer >= phase3Time && globalTimer < phase3Time + phasechangeTime){
            Debug.Log("Phase 3 delay" + globalTimer);
            spawnDelay = 100f;
        }
        //Phase 4
        else if (globalTimer >= phase3Time && globalTimer < phase4Time){
            Debug.Log("Phase 4" + globalTimer);
            minSides = 5;
            maxSides = 5;
            spawnDelay = 1.1f;
            shrinkSpeed = 1.7f;
        }
        //Delay in between phases
        else if (globalTimer >= phase4Time && globalTimer < phase4Time + phasechangeTime){
            Debug.Log("Phase 4 delay" + globalTimer);
            spawnDelay = 100f;
        }
        //Phase 5
        else if (globalTimer >= phase4Time && globalTimer < phase5Time){
            Debug.Log("Phase 5" + globalTimer);
            minSides = 1;
            maxSides = 5;
            spawnDelay = 0.55f;
            shrinkSpeed = 1.2f;
        }
        //Delay in Between Phases
        else if (globalTimer >= phase5Time && globalTimer < phase5Time + phasechangeTime){
            Debug.Log("Phase 5 delay" + globalTimer);
            spawnDelay = 100f;
        }
        //Phase 6
        else if (globalTimer >= phase5Time){
            Debug.Log("Phase 6" + globalTimer);
            minSides = 3;
            maxSides = 5;
            spawnDelay = 0.5f;
            shrinkSpeed = 1.7f;
        }

        if(timer >= spawnDelay){
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
        spawnedPolygon.GetComponent<PolygonController>().shrinkSpeed = shrinkSpeed;
    }

}
