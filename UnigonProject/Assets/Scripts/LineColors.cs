using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColors : MonoBehaviour
{

    [SerializeField] float colorChangeSpeed = 0.005f;
    public float hue = 0.5f;
    public bool goingUp = true;
    void Start(){
    }
    void FixedUpdate(){    
        UpdateLineColors();
    }
    
void UpdateLineColors(){
    // Obtén el color de fondo actual
    Color backgroundColor = Camera.main.backgroundColor;

    // Convierte el color de fondo a HSV
    Color.RGBToHSV(backgroundColor, out float H, out float S, out float V);

    // Aumenta el valor de V para hacer el color más claro
    V = Mathf.Clamp(V + 0.2f, 0, 1); // Asegúrate de que V esté entre 0 y 1

    // Convierte el color HSV de nuevo a RGB
    Color newColor = Color.HSVToRGB(H, S, V);

    // Aplica el nuevo color al LineRenderer
    GetComponent<LineRenderer>().material.color = newColor;
}

}
