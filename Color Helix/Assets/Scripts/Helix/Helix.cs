using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    bool movable = true;

    float angle;
    float lastDeltaAngle , lastTouchX;

    void Update() 
    {
        if(GameController.instance.gameOver){ return; }
        if(movable && Touch.IsPressing())
        {
            float mouseX = this.GetMouseX();
            lastDeltaAngle = lastTouchX - mouseX;
            angle += lastDeltaAngle * 360 * 1.7f;
            lastTouchX = mouseX;
        }
        else if(lastDeltaAngle != 0)
        {
            lastDeltaAngle -= lastDeltaAngle * 5 * Time.deltaTime;
            angle += lastDeltaAngle * 360 * 1.7f;
        }

        transform.eulerAngles = new Vector3(0,0,angle);
    }

    float GetMouseX()
    {
        return Input.mousePosition.x / (float)Screen.width;
    }
}
