using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenHandler : MonoBehaviour
{
    GameObject camera;
    void Awake(){
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        GetComponent<AudioSource>().Play();
        StartCoroutine(camera.GetComponent<CameraController>().Shaking());
    }
    public void PlayGame(){
        SceneManager.LoadScene("GameScene1");
    }
    public void QuitMenu(){
        SceneManager.LoadScene("MainMenu");   
    } 
}
