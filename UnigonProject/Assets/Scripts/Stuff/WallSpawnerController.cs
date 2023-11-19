using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerController : MonoBehaviour
{
    public GameObject wallPrefab;
    public int numberOfWalls = 5;
    public float spawnRadius = 5f;
    public float spawnInterval = 1f; // Time between spawns

    void Start()
    {
        // Start the coroutine for continuous spawning
        StartCoroutine(SpawnWallsContinuously());
    }

    IEnumerator SpawnWallsContinuously()
    {
        while (true)
        {
            SpawnWalls();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnWalls()
    {
        Vector3 centerPosition = new Vector3(0, -3, 0);

        for (int i = 0; i < numberOfWalls; i++)
        {
            // Calculate a random angle in radians
            float angleRad = Random.Range(0f, 2f * Mathf.PI);

            // Calculate a random position around the center within the spawnRadius
            Vector3 spawnPosition = centerPosition + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * spawnRadius;

            // Calculate the rotation based on the angle
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angleRad - 90f);

            // Instantiate the wall prefab at the random position with rotation
            GameObject newWall = Instantiate(wallPrefab, spawnPosition, spawnRotation);

            // Optionally, you can parent the walls to this spawner for better organization
            newWall.transform.parent = transform;
        }
    }
}
