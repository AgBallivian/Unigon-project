using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 direction;

    void Start() {
        direction = new Vector3(0, -1, 0);
    }

    void Update()
    {
        ObjectMovementTransform();
    }

    public void ObjectMovementTransform()
    {
        Vector3 newPosition = transform.position + direction.normalized * speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
