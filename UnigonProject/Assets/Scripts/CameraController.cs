using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float rotationSpeed = 5f;  // Adjust this to control camera rotation speed

    void Update()
    {
        // Get the player's position and rotation
        Vector3 playerPos = player.position;
        Quaternion playerRot = player.rotation;

        // Set the camera position to follow the player
        transform.position = playerPos + playerRot * new Vector3(0, 0, -10);  // Adjust the values as needed

        // Tilt the camera to match the player's rotation
        transform.rotation = Quaternion.LookRotation(playerPos - transform.position, playerRot * Vector3.up);

        // Optionally, you can rotate the camera around the player
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(playerPos, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
