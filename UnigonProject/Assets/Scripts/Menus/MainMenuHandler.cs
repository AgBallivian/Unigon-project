using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    public AudioSource TitleAudio;
    public AudioSource Soundy;

    public TextMeshProUGUI timertextHighScoreLv1;
    public TextMeshProUGUI timertextHighScoreLv2;

    void Start(){
        TitleAudio.Play();
        Soundy.Play();

        //Display Score
        timertextHighScoreLv1.text = "Highest Time: " + PlayerPrefs.GetFloat("HighestTimeLv1", 0).ToString("0.00");
        timertextHighScoreLv2.text = "Highest Time: " + PlayerPrefs.GetFloat("HighestTimeLv2", 0).ToString("0.00");
    }

    public void ResetRecords(){
        PlayerPrefs.DeleteAll();
        timertextHighScoreLv1.text = "Highest Time: " + PlayerPrefs.GetFloat("HighestTimeLv1", 0).ToString("0.00");
        timertextHighScoreLv2.text = "Highest Time: " + PlayerPrefs.GetFloat("HighestTimeLv2", 0).ToString("0.00");
    }

    public void LevelSelection(){
        SceneManager.LoadScene("Level Selection");
    }

    public void Tutorial(){
        SceneManager.LoadScene("GameSceneTUT");
    }

    public void Level1(){
        SceneManager.LoadScene("GameScene1");
    }

    public void Level2(){
        SceneManager.LoadScene("GameScene2");
    }
    
    public void titleScreen(){
        SceneManager.LoadScene("Main Menu");
    }

    public void Settings(){
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    } 
}
