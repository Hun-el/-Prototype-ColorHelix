using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFragment : MonoBehaviour
{
    MeshRenderer meshRenderer;

    void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start() 
    {
        if(this.gameObject.tag == "Hit")
        {
            meshRenderer.material.color = GameController.instance.hitColor;

            GameObject[] colorBumbs = GameObject.FindGameObjectsWithTag("ColorBump");
            float minDistance = 999f;
            foreach(GameObject colorBumb in colorBumbs)
            {
                if(Vector3.Distance(transform.position , colorBumb.transform.position) < minDistance)
                {
                    if(transform.position.z > colorBumb.transform.position.z)
                    {
                        meshRenderer.material.color = colorBumb.GetComponent<ColorBump>().GetColor();
                        GameController.instance.hitColor = colorBumb.GetComponent<ColorBump>().GetColor();
                    }
                }
            }
        }
        else
        {  
            if(GameController.instance.failColor == GameController.instance.hitColor)
            {
                GameController.instance.failColor = GameController.instance.colors[Random.Range(0,GameController.instance.colors.Length)];
            }
            meshRenderer.material.color = GameController.instance.failColor;
        }
    }
}
