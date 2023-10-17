using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private float scaleFactor = 0.5f;
    private float maxScale = 5.0f; // Set your desired maximum scale value here

    void Update()
    {
        ObjectMovementTransform();
    }

    public void ObjectMovementTransform()
    {
        // Set the target position to the center (0, -3, 0)
        Vector3 targetPosition = new Vector3(0, -3, 0);
        // Direction towards the center
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Distance to the center
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Scale factor
        float actualScaleFactor = distance * scaleFactor;

        // Clamp the scale to the maximum value
        actualScaleFactor = Mathf.Clamp(actualScaleFactor, 0f, maxScale);

        // Update the scale of the object in all directions
        transform.localScale = new Vector3(actualScaleFactor, actualScaleFactor * 0.7f, actualScaleFactor);

        // Move towards the center
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
