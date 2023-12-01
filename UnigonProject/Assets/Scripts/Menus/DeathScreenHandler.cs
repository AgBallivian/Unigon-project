using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreenHandler : MonoBehaviour
{
    GameObject camera;
    public TextMeshProUGUI timertextScore;
    public TextMeshProUGUI timertextHighScore;

    void Awake(){
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        GetComponent<AudioSource>().Play();
        StartCoroutine(camera.GetComponent<CameraController>().Shaking());

        //Display Score
        timertextScore.text = "Time:      " + TimerText.currenttime.ToString("0.00");
        //Get the Highscore from the level that is active
        if (Level1Controller.ActualSceneisActive){
            timertextHighScore.text = "Highest: " + PlayerPrefs.GetFloat("HighestTimeLv1", 0).ToString("0.00");
        }
        if (Level2Controller.ActualSceneisActive){
            timertextHighScore.text = "Highest: " + PlayerPrefs.GetFloat("HighestTimeLv2", 0).ToString("0.00");
        }
        
        

    }
    public void PlayGame(){

        if (TutorialController.ActualSceneisActive){
            SceneManager.LoadScene("GameSceneTUT");
        }
        if (Level1Controller.ActualSceneisActive){
            SceneManager.LoadScene("GameScene1");
        }
        if (Level2Controller.ActualSceneisActive){
            SceneManager.LoadScene("GameScene2");
        }
        // if (Level1Controller.ActualSceneisActive){
        //     SceneManager.LoadScene("GameScene3");
        // }
        // //TODO: FIX THIS SO IT GOES TO THE CORRECT LEVEL.
        // SceneManager.LoadScene("GameScene1");
    }
    public void QuitMenu(){
        if (TutorialController.ActualSceneisActive){
            TutorialController.ActualSceneisActive = false;
        }
        if (Level1Controller.ActualSceneisActive){
            Level1Controller.ActualSceneisActive = false;
        }
        if (Level2Controller.ActualSceneisActive){
            Level2Controller.ActualSceneisActive = false;
        }
        SceneManager.LoadScene("Main Menu");   

    } 
}
