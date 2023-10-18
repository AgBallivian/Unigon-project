using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float shrinkSpeed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if(transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
        }
    }
}
