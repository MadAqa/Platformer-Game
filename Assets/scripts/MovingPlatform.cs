using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint, endPoint;
    public float speed, directionLook;
    int direction = 1;
    private void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target,speed);
        float distance = (target - (Vector2)platform.position).magnitude;
        if(distance < speed)
        {
            direction *=-1;
        }
       // platform.LookAt(target);

    }
    Vector2 currentMovementTarget() { 
        if (direction==1) {
            
            return startPoint.position; 
        }
        else {  return endPoint.position; }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint !=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position , startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

}
