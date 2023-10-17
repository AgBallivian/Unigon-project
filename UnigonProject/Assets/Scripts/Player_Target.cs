using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Target : MonoBehaviour
{
    Player_Controller playerController;

    void Awake() {
        playerController = GetComponent<Player_Controller>();
    }
    //Player health

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            playerController.hit();
        }
    }
}
