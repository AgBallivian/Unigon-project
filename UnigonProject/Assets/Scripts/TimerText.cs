using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    public static float currenttime;

    void Start(){
        currenttime = 0f;
    }

    void Update(){
        currenttime = currenttime += Time.deltaTime;
        timertext.text = currenttime.ToString("0.00");

        CheckHighestTime();
    }

    void CheckHighestTime(){
        //Check What level is active
        if (Level1Controller.ActualSceneisActive){
            if(currenttime > PlayerPrefs.GetFloat("HighestTimeLv1", 0)){
            PlayerPrefs.SetFloat("HighestTimeLv1", currenttime);
            }
        }
        if (Level2Controller.ActualSceneisActive){
            if(currenttime > PlayerPrefs.GetFloat("HighestTimeLv2", 0)){
            PlayerPrefs.SetFloat("HighestTimeLv2", currenttime);
            }
        }
    }
}
