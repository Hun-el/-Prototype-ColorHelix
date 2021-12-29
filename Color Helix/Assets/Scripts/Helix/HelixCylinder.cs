using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixCylinder : MonoBehaviour
{
    GameObject helix;

    void Awake() 
    {
        helix = GameObject.FindGameObjectWithTag("Helix");
    }

    void Update() 
    {
        transform.eulerAngles = new Vector3(0,0,helix.transform.eulerAngles.z % 25);
    }
}
