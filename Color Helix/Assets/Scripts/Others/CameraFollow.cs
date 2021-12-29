using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float cameraZ;

    void Update() 
    {
        cameraZ = Ball.GetZ() - 3f;

        transform.position = new Vector3(0,2f, cameraZ);
    }
}
