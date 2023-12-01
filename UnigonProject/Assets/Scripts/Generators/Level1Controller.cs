using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour
{
    public GeneratorLvL generatorLvL;
    public ColorChange colorChange;

    public Color color1;
    public Color color2;
    
    //Phases for each 15 seconds until 60
    //after 60+ seconds, every 30 seconds 
    //Ends at 120 seconds
    private float normalStage = 60.0f;
    private float hardStage = 120.0f;

    private float normalPhaseTime = 15.0f;
    private float hardPhaseTime = 30.0f;
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
        if(globalTimer <= normalStage){
            if(timer >= normalPhaseTime){
                stage++;
                Debug.Log("Stage normal: " + stage + "Time: " + timer + "Global: " + globalTimer);
                timer = 0.0f;
                OnLevelUp();
            }
        }
        else if(globalTimer > normalStage && globalTimer <= hardStage ){
            if(timer >= hardPhaseTime){
                stage++;
                Debug.Log("Stage hard: " + stage + "Time: " + timer + "Global: " + globalTimer);
                timer = 0.0f;
                OnLevelUp();
            }
        }
        else if(globalTimer > normalStage && globalTimer > hardStage) {
            //TODO: Change to next Level
            stage = 99;
            Debug.Log("Stage inf: " + stage + "Time: " + timer + "Global: " + globalTimer);
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
            case 0: //0-15 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 1: //15-30 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 2: //30-45 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 0.9f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 3: //45-60 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 0.8f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 4: //60-90 seconds
            generatorLvL.patternchangeTime = 4.0f;
            generatorLvL.patternSpeedTime = 1.2f;
            generatorLvL.shrinkSpeed = 1.0f;

            //Change colors
            colorChange.colorPairs[0].color1 = color1;
            colorChange.colorPairs[0].color2 = color2;
            break;
            case 5: //90-120 seconds
            generatorLvL.patternchangeTime = 4.0f;
            generatorLvL.patternSpeedTime = 1.1f;
            generatorLvL.shrinkSpeed = 1.1f;

            //Change colors
            colorChange.colorPairs[0].color1 = color1;
            colorChange.colorPairs[0].color2 = color2;
            break;
            case 99: //120+ seconds
            generatorLvL.patternchangeTime = 3.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 1.3f;

            //Change colors
            colorChange.colorPairs[0].color1 = color1;
            colorChange.colorPairs[0].color2 = color2;
            break;
        }
    }
}

