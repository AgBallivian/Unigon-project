using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    public float currenttime;

    void Update(){
        currenttime = currenttime += Time.deltaTime;
        timertext.text = currenttime.ToString("0.00");
    }
}
