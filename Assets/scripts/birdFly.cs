using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly : MonoBehaviour
{
    
    public Transform platform;
    public Transform startPoint, endPoint;
    public float speed;
    int direction = 1;
    private void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target, speed);
        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance < speed)
        {
            direction *= -1;
        }
        Vector3 currentRotation = platform.eulerAngles;
        // Change the rotation.y based on the direction and the desired angle
        if (direction == 1) // Moving towards the start point
        {
            currentRotation.y = 180; // Face the positive x-axis
        }
        else // Moving towards the end point
        {
            currentRotation.y = 0; // Face the negative x-axis
        }
        // Set the new rotation of the platform
        platform.eulerAngles = currentRotation;

    }
    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {

            return startPoint.position;
        }
        else { return endPoint.position; }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

}


