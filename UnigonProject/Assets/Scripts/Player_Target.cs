using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Target : MonoBehaviour
{

    Player_Controller playerController;
    GameObject camera;

    void Awake() {
        playerController = GetComponent<Player_Controller>();
        //get gameobject camera by tag
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    //Player health

    void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Enemy")){
        Vector2 impactDirection = (other.transform.position - transform.position).normalized;
        Vector2 playerFront = transform.right; // Asume que el frente del jugador es su derecha

        float dotProduct = Vector2.Dot(impactDirection, playerFront);
        Debug.Log(dotProduct);
        if(dotProduct > 0){
            Debug.Log("Impacto frontal");
        } else {
            Debug.Log("Impacto lateral");
        }

        playerController.hit();
        //Make Hit sound
        GetComponent<AudioSource>().Play();
        //Call the camera shake function
        StartCoroutine(camera.GetComponent<CameraController>().Shaking());
    }
    }
}
