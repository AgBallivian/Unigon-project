using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPolyController : MonoBehaviour
{
    //Get GeneratePoly script
    PoligonGenerator generatePoly;
    void Awake() {
        generatePoly = GetComponent<PoligonGenerator>();
    }
    // Update is called once per frame
    void FixedUpdate() {
        
        //rotate the poly
        transform.Rotate(0,0,1);
        //Change how many sides the poly has every 2 seconds
        if(Time.timeSinceLevelLoad % 2 < 0.1f){
            generatePoly.sides = Random.Range(3, 10);
        }

    }
}
