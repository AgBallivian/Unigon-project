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
            playerController.hit();
            //Call the camera shake function
            StartCoroutine(camera.GetComponent<CameraController>().Shaking());
        }
    }
}
