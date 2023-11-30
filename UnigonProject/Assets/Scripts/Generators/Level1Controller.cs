using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public GeneratorLvL generatorLvL;
    
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

    void Start(){
        audio = GetComponents<AudioSource>();
    }
    void FixedUpdate(){
        globalTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if(globalTimer <= normalStage){
            if(timer >= normalPhaseTime && generatorLvL.patternFinish == true){
                stage++;
                Debug.Log("Stage normal: " + stage);
                timer = 0.0f;
            }
        }
        else if(globalTimer > normalStage && globalTimer <= hardStage ){
            if(timer >= hardPhaseTime && generatorLvL.patternFinish == true){
                stage++;
                Debug.Log("Stage hard: " + stage);
                timer = 0.0f;
            }
        }
        else if(globalTimer > normalStage && globalTimer > hardStage) {
            stage = 99;
            Debug.Log("Stage inf: " + stage);
        }
        stages();
    }

    private void OnLevelUp(){
        audio[0].Play();
        audio[1].Play();
    }

    private void stages(){
        if (timer < stageBuffer){
            return;
        }
        switch(stage){
            case 0: //0-15 seconds
            generatorLvL.patternchangeTime = 5.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 1: //15-30 seconds
            generatorLvL.patternchangeTime = 4.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 2: //30-45 seconds
            generatorLvL.patternchangeTime = 4.0f;
            generatorLvL.patternSpeedTime = 1.2f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 3: //45-60 seconds
            generatorLvL.patternchangeTime = 4.0f;
            generatorLvL.patternSpeedTime = 0.9f;
            generatorLvL.shrinkSpeed = 0.7f;
            break;
            case 4: //60-90 seconds
            generatorLvL.patternchangeTime = 6.0f;
            generatorLvL.patternSpeedTime = 1.2f;
            generatorLvL.shrinkSpeed = 0.8f;
            break;
            case 5: //90-120 seconds
            generatorLvL.patternchangeTime = 6.0f;
            generatorLvL.patternSpeedTime = 1.1f;
            generatorLvL.shrinkSpeed = 0.9f;
            break;
            case 99: //120+ seconds
            generatorLvL.patternchangeTime = 6.0f;
            generatorLvL.patternSpeedTime = 1.0f;
            generatorLvL.shrinkSpeed = 0.9f;
            break;
        }
    }
}

