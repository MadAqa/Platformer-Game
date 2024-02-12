using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cameraTest : MonoBehaviour
{
    public Transform cam;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(cam.position.x + speed, cam.position.y, cam.position.z);
    }
}
