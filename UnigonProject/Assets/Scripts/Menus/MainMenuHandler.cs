using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("GameScene1");
    }
    public void PlayGameHARD(){
        SceneManager.LoadScene("GameScene2");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    } 
}
