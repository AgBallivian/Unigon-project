using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLv1 : MonoBehaviour
{
    public GameObject polygonPrefab;
    public float patternchangeTime = 10.0f;
    public float patternSpeedTime = 0.5f;

    //temporal Randomess (ADD PATTERNS NEXT UPDATE)
    // public float spawnDelay = 1f;
    public float shrinkSpeed = 0.7f;

    private float timer;
    private float globalTimer;

    private List<float> possibleAngles = new List<float>();
    public int polygonSides = 8;

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
            //TODO: Optimizar le elecion random de pattrones (?)
            int randomPattern = Random.Range(0, 3);
            // int randomPattern = 0;

            //Cambiarlo a un switch case
            if(randomPattern == 0){
                // Debug.Log("Spawning 111 ; Time: " + patternchangeTime);
                StartCoroutine(patt_2on2());
            }
            if(randomPattern == 1){
                // Debug.Log("Spawning 3c ; Time: " + patternchangeTime);
                StartCoroutine(patt_3c());
            }
            if(randomPattern == 2){
                StartCoroutine(patt_alt2s());
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

        //DELAY SO PATTERNS DON'T OVERLAP   
        //TODO: OPTIMIZAR ESTA WEA
        yield return new WaitForSeconds(patternchangeTime);
    }
    
    private IEnumerator patt_2on2()
    {
        //FIX THIS PATTERN IS IMPOSIIBLE TO DODGE when it comes
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
        yield return new WaitForSeconds(patternSpeedTime);
        //DELAY SO PATTERNS DON'T OVERLAP   
        //TODO: OPTIMIZAR ESTA WEA
        yield return new WaitForSeconds(patternchangeTime);
    }

    private IEnumerator patt_alt2s()
    {
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
            Debug.Log("spawn angle: " + spawnAngle + " ; i: " + i);
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

        //DELAY SO PATTERNS DON'T OVERLAP   
        //TODO: OPTIMIZAR ESTA WEA
        yield return new WaitForSeconds(patternchangeTime);
    }

    private IEnumerator patt_spiral()
    {

        //DELAY SO PATTERNS DON'T OVERLAP   
        //TODO: OPTIMIZAR ESTA WEA
        yield return new WaitForSeconds(patternchangeTime);
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
