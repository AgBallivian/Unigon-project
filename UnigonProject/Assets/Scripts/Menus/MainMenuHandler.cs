using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public AudioSource TitleAudio;
    public AudioSource Soundy;

    void Start(){
        TitleAudio.Play();
        Soundy.Play();
    }

    public void LevelSelection(){
        SceneManager.LoadScene("Level Selection");
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
