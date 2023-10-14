using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPrefabController : MonoBehaviour
{
    public GameObject wallPrefab;

    public GameObject SpawnWall(Vector3 position, Quaternion rotation)
    {
        GameObject newWall = Instantiate(wallPrefab, position, rotation);
        return newWall;
    }
}
