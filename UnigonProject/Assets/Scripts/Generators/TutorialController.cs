using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    //Textmeshpro for tutorial
    public TextMeshProUGUI tutorialText;

    public GeneratorTUTORIAL generatorLvL;
    public ColorChange colorChange;

    public Color color1;
    public Color color2;
    
    //Phases for each 15 seconds until 60
    //after 60+ seconds, every 30 seconds 
    //Ends at 120 seconds
    private float tutorialStage = 60.0f;
    private float PlayStage = 120.0f;

    private float tutorialPhaseTime = 10.0f;
    private float PlayPhaseTime = 30.0f;
    private float timer;
    private float globalTimer;

    private float stageBuffer = 1.0f;
    private int stage = 0;

    public AudioSource AudioClip1;
    public AudioSource AudioClip2;

    public static bool ActualSceneisActive = false;

    void Start(){
        ActualSceneisActive = true;
    }

    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;
        // Managa tutorial text with timer
        if(globalTimer <= tutorialStage){
            if(timer >= tutorialPhaseTime){
                stage++;
                Debug.Log("Stage tutorial: " + stage + "Time: " + timer + "Global: " + globalTimer);
                timer = 0.0f;
                OnLevelUp();
            }
        }
        else if(globalTimer > tutorialStage && globalTimer <= PlayStage ){
            if(timer >= PlayPhaseTime){
                stage++;
                Debug.Log("Stage Play: " + stage + "Time: " + timer + "Global: " + globalTimer);
                timer = 0.0f;
                OnLevelUp();
            }
        }
        else if(globalTimer > tutorialStage && globalTimer > PlayStage) {
            stage = 99;
        }
        stages();
    }

    private void OnLevelUp(){
        AudioClip1.Play();
        AudioClip2.Play();
    }

    private void stages(){
        // if (timer < stageBuffer){
        //     return;
        // }
        switch(stage){
            case 0: //0-10 seconds
            generatorLvL.patternchangeTime = 8.0f;
            generatorLvL.patternSpeedTime = 2.0f;
            generatorLvL.shrinkSpeed = 0.6f;
            break;
            case 1: //10-30 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 2.0f;
            generatorLvL.shrinkSpeed = 0.6f;
            //Text Change
            tutorialText.text = "Avoid the walls! \nRemember you only have 3 lives";
            tutorialPhaseTime = 20.0f;
            break;
            case 2: //30-60 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 2.0f;
            generatorLvL.shrinkSpeed = 0.6f;
            //Text Change
            tutorialText.text = "In some levels you can 'FLIP' and rotate 180 inmidiatly! \n use 'SPACE' to flip!";
            tutorialPhaseTime = 30.0f;
            break;
            case 3: //60-90 seconds
            generatorLvL.patternchangeTime = 6.0f;
            generatorLvL.patternSpeedTime = 1.1f;
            generatorLvL.shrinkSpeed = 0.6f;
            tutorialText.text = "With more time, the Harder it gets!";
            break;
            case 4: //90-120 seconds
            generatorLvL.patternchangeTime = 6.0f;
            generatorLvL.patternSpeedTime = 1.4f;
            generatorLvL.shrinkSpeed = 0.6f;
            tutorialText.text = "With 120 Seconds you Complete the Tutorial! \n Good Luck!";
            break;
            case 5: //120+ seconds
            SceneManager.LoadScene("Main Menu");
            break;
            break;
        }
    }
}

