using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    public float Rotation_speed = 1.0f;
    void FixedUpdate()
    {
        transform.Rotate(0,0,Rotation_speed);
    }
}
