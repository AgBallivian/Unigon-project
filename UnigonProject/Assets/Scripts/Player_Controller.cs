using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 650f;

    float movement;

    //Custom position for the player to rotate around (0,-3,0)
    Vector3 position = new Vector3(0, -3, 0);
    void Update(){
        movement = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate (){
        //Rotate around the custom position
        transform.RotateAround(position, Vector3.forward, movement * Time.fixedDeltaTime * -speed);
        
    }
}
