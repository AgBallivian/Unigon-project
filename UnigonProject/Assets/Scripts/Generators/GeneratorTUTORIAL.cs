using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTUTORIAL : MonoBehaviour
{
    public GameObject polygonPrefab;
    public float patternchangeTime = 5.0f;
    public float patternSpeedTime = 1.0f;
    public float timerStartBuffer = 5.0f;

    public float shrinkSpeed = 0.7f;

    private float timer;
    private float globalTimer;
    public bool patternFinish = true;

    private List<float> possibleAngles = new List<float>();
    public int polygonSides = 8;

    void Start(){
        //Create Posible angles to spawn the polygon (Regular Polygon)
        int polygonSides = polygonPrefab.GetComponent<PolygonSideGenerator>().sides;
        float angleStep = 360f / (polygonSides*2); 
        // Debug.Log(angleStep + " " + polygonSides*2);
        for (int i = 0; i < polygonSides; i++)
        {
            // Debug.Log(angleStep*i);
            possibleAngles.Add(angleStep * i);
        }
        timer = timerStartBuffer;
    }

    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if(timer >= patternchangeTime && patternFinish == true){
            //TODO: Optimizar le elecion random de pattrones (?)
            int randomPattern = Random.Range(0, 4);
            // int randomPattern = 6;

            if(randomPattern == 0){
                // Debug.Log("Spawning 3c ;");
                StartCoroutine(patt_3c());
            }
            if(randomPattern == 1){
                // Debug.Log("Spawning alt2s ;");
                StartCoroutine(patt_alt2s());
            }
            if(randomPattern == 2){
                // Debug.Log("Spawning rand ;");
                StartCoroutine(patt_rand());
            }
            if (randomPattern == 3){
                // Debug.Log("Spawning 6BigMinic ;");
                StartCoroutine(patt_6BigMinic());
            }
            
            
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
    private IEnumerator patt_3c()
    {
        patternFinish = false;
        // Choose a random angle from the list
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle);

        //Spawn wall 1 of 3
        SpawnWall(polygonSides, polygonSides - 1, spawnRotation);
        yield return new WaitForSeconds(patternSpeedTime);
        //Spawn wall 2 of 3
        Quaternion spawnRotation2 = Quaternion.Euler(0f, 0f, spawnAngle + 90f);
        SpawnWall(polygonSides, polygonSides - 1, spawnRotation2);
        yield return new WaitForSeconds(patternSpeedTime);
        //Spawn wall 3 of 3
        Quaternion spawnRotation3 = Quaternion.Euler(0f, 0f, spawnAngle);
        SpawnWall(polygonSides, polygonSides - 1, spawnRotation3);
        yield return new WaitForSeconds(patternSpeedTime);

        //Confirms that pattern ended so next can be spawned  
        patternFinish = true;
    }
    
    private IEnumerator patt_2on2()
    {
        patternFinish = false;
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
        int indx = randomAngleIndex;
        for(int i = 0; i<polygonSides; i++){
            // Debug.Log("spawn angle: " + spawnAngle + " ; i: " + i);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, 1, spawnRotation);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle+90f); 
            SpawnWall(polygonSides, 1, spawnRotation);
            yield return new WaitForSeconds(0.7f);
            
            
            indx = indx + 1; 
            if (indx >= possibleAngles.Count){
                indx = 0;
            }
            
            spawnAngle = possibleAngles[indx];
        }
        for(int i = 0; i<3; i++){
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, 1, spawnRotation);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle+90f); 
            SpawnWall(polygonSides, 1, spawnRotation);
            yield return new WaitForSeconds(0.1f);
            
            
            spawnAngle = possibleAngles[indx];
        }
        patternFinish = true;   
    }

    private IEnumerator patt_alt2s()
    {
        patternFinish = false;
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
        int indx = randomAngleIndex;
        int indx2 = indx + 1;
        if (indx2 >= possibleAngles.Count){
            indx2 = 0;
        }
        for(int i = 0; i<polygonSides/2; i++){
            int now = indx;
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, 2, spawnRotation);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle+90f); 
            SpawnWall(polygonSides, 2, spawnRotation);
            yield return new WaitForSeconds(0.7f);
            
            if(i%2==0){
                now = indx2;
            } else {
                now = indx;
            }
            spawnAngle = possibleAngles[now];
        }

        patternFinish = true;
    }

    private IEnumerator patt_spiral()
    {
        patternFinish = false;
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
        int indx = randomAngleIndex;

        for(int i = 0; i<polygonSides; i++){

            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, polygonSides-1, spawnRotation);

            yield return new WaitForSeconds(patternSpeedTime);
            indx = indx + 1;
            if (indx >= possibleAngles.Count){
                indx = 0;
            }
            spawnAngle = possibleAngles[indx];
        }

        //DELAY SO PATTERNS DON'T OVERLAP   
        //TODO: OPTIMIZAR ESTA WEA NO FUNCIONA
        patternFinish = true;
    }

    private IEnumerator patt_rand()
    {
        patternFinish = false;
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
        int wallscount = Random.Range(3, polygonSides);
        for(int i = 0; i<polygonSides; i++){

            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, wallscount, spawnRotation);

            yield return new WaitForSeconds(patternSpeedTime);
            randomAngleIndex = Random.Range(0, possibleAngles.Count);
            spawnAngle = possibleAngles[randomAngleIndex];
            wallscount = Random.Range(3, polygonSides-1);
        }

        patternFinish = true;
    }

    private IEnumerator patt_Big2sid()
    {
        patternFinish = false;
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        float newAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
        int indx = randomAngleIndex;
        for(int i = 0; i<polygonSides*2; i++){

            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, 1, spawnRotation);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle+90f); 
            SpawnWall(polygonSides, 1, spawnRotation);

            //Spawn in between
            randomAngleIndex = Random.Range(0, possibleAngles.Count);
            newAngle = possibleAngles[randomAngleIndex];
            spawnRotation = Quaternion.Euler(0f, 0f, newAngle);
            SpawnWall(polygonSides, 1, spawnRotation);

            yield return new WaitForSeconds(patternSpeedTime/2);
        }

        patternFinish = true;   
    }

    private IEnumerator patt_6BigMinic()
    {
        patternFinish = false;
        // Choose a random angle from the list
        int randomAngleIndex = Random.Range(0, possibleAngles.Count);
        float spawnAngle = possibleAngles[randomAngleIndex];
        // Rotate around z-axis
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle);

        for(int i = 0; i<6; i++){
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle); 
            SpawnWall(polygonSides, polygonSides-2, spawnRotation);
            yield return new WaitForSeconds(patternSpeedTime);
            spawnRotation = Quaternion.Euler(0f, 0f, spawnAngle+90f); 
            SpawnWall(polygonSides, polygonSides-2, spawnRotation);
            yield return new WaitForSeconds(patternSpeedTime);
        }

        //Confirms that pattern ended so next can be spawned  
        patternFinish = true;
    }

    //Spawn the wall function 
    private void SpawnWall(int sides, int sidesToCreate, Quaternion spawnRotation)
    {
        // Debug.Log("Angle of spawn: " + spawnRotation.eulerAngles.z);
        Vector3 spawnPosition = new Vector3(0f, -3f, 0f);
        GameObject spawnedPolygon = Instantiate(polygonPrefab, spawnPosition, spawnRotation);
        spawnedPolygon.GetComponent<PolygonSideGenerator>().sides = sides;
        spawnedPolygon.GetComponent<PolygonSideGenerator>().sidesToCreate = sidesToCreate;
        spawnedPolygon.GetComponent<PolygonController>().shrinkSpeed = shrinkSpeed;

    }
}
