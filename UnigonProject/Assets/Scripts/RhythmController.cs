using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    //Music Movement
    [Header("Music Movement")]
    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    //music data
    public float clipLoudness;
    private float[] clipSampleData;

    //What to move
    public GameObject sprite;
    public float sizeFactor = 1f;
    public float minSize = 1f;
    public float maxSize = 1.2f;

    private void Awake() {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update(){
        currentUpdateTime += Time.deltaTime;
        if(currentUpdateTime >= updateStep){
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;
            clipLoudness *= sizeFactor;
            // clipLoudness = Mathf.Clamp(clipLoudness * sizeFactor, minSize, maxSize);
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, 1f);
        }
    }
    //Used this:
    //https://youtu.be/LlkdQSjXd_A
}
