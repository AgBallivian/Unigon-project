using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shadowPrefab;
    public int ShadowCount = 1;

    public float shrinkSpeed = 0.7f;


    // Start is called before the first frame update
    void Start()
    {
        // rb.rotation = Random.Range(0f, 360f);
        // rb.rotation = 90f;
        transform.localScale = Vector3.one * 4f;

        //Create Shadow form prefab
        // CreateShadow();

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

    void CreateShadow()
    {
        for (int i = 0; i < ShadowCount; i++)
        {
            GameObject shadow = Instantiate(shadowPrefab, transform.position, transform.rotation);
            float offset = -0.5f * (i + 1);
            shadow.transform.localScale = transform.localScale + new Vector3(0f, offset, 0f);
            //Create the same ammount of walls as the original polygon

        }
    }
}
