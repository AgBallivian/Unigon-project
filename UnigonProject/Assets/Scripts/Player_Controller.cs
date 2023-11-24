using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    //Health System
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool GodMode = false;

    public float speed = 350f;
    public float acceleration = 5f;

    float movement;

    //Custom position for the player to rotate around (0,-3,0)
    Vector3 position = new Vector3(0, -3, 0);
    void Update(){
        movement = Input.GetAxisRaw("Horizontal");
        
        if (movement == 0) {
        currentSpeed = 0;
        }
        //heartDisplay
        heartsDisplay();

    }
    private float currentSpeed = 0f;
    void FixedUpdate (){
        if (currentSpeed < speed) {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Min(currentSpeed, speed); 
        }
        transform.RotateAround(position, Vector3.forward, movement * Time.fixedDeltaTime * -currentSpeed);
    }
    //Display the health system
    void heartsDisplay(){
        
        if(health > numOfHearts){
            health = numOfHearts;
        }
        for(int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }

    //Health System
    public void hit(){
        health--;
        if(health <= 0 && !GodMode){
            death();
        }
    }

    public void death(){
        //placeholder for death animation 
        Debug.Log("Player is dead");
        //After this it should be send to a retry screen or back to the deathScreen
        SceneManager.LoadScene("DeathScreen");

    }
}
