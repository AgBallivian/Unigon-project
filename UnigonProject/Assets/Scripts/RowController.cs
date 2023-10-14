using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{

    public GameObject DeathSpawn;
    public float SpawnDelay = 1f;
    //Evey how many seconds the spawn delay decreases
    //Adds a little dificulty the longer you play
    public float SpawnIncrease = 10f;

    private float timer;
    private float globalTimer;

    void Update(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;
        //Increment spawns every 10 seconds
        if(globalTimer >= SpawnIncrease){
            SpawnDelay -= 0.05f;
            globalTimer = 0;
        }
        //Stop going below 0.1f
        if(SpawnDelay <= 0.1f){
            SpawnDelay = 0.1f;
        }
        if(timer >= SpawnDelay){
            SpawnObject();
            timer = 0;
        }
    }
        // Instance of the prefab
    public void SpawnObject()
    {      
        //Spaw in position of row
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            transform.position.y,
            0
        );
        GameObject objectSpawn = DeathSpawn;
        Instantiate(objectSpawn, spawnPos, Quaternion.identity);

        if (objectSpawn.TryGetComponent<Collider2D>(out Collider2D collider)){
            collider.isTrigger = true; 
        }
        
    }

}