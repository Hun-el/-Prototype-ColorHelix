using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject finishLine;

    public Color[] colors;
    public Color hitColor,failColor;

    int wallsCount = 15;
    float z = 3;

    bool colorBump;

    public bool gameOver;

    void Awake() 
    {
        instance = this;
        GenerateColors();
    }

    void Start() 
    {
        SpawnWalls();
    }

    void GenerateColors()
    {
        hitColor = colors[Random.Range(0,colors.Length)];
        failColor = colors[Random.Range(0,colors.Length)];
        while(failColor == hitColor)
        {
            failColor = colors[Random.Range(0,colors.Length)];
        }

        Ball.SetColor(hitColor);
    }
    
    void SpawnWalls()
    {
        for(int i = 0; i < wallsCount; i++)
        {
            GameObject wall;

            if(Random.value <= 0.2f && !colorBump && i > 1 && i != wallsCount - 1)
            {
                colorBump = true;
                wall = Instantiate(Resources.Load("ColorBump") as GameObject,transform.position,Quaternion.identity);
                wall.transform.localPosition = new Vector3(0,0,z*2);

                Color randomColor = colors[Random.Range(0,colors.Length)];
                wall.GetComponent<ColorBump>().SetColor(randomColor);
            }
            else
            {
                colorBump = false;
                wall = Instantiate(Resources.Load("Wall") as GameObject,transform.position,Quaternion.identity);
                wall.transform.localPosition = new Vector3(0,0,z);
            }

            wall.transform.SetParent(GameObject.Find("Helix").transform);
            float randomRot = Random.Range(0,360);
            wall.transform.localRotation = Quaternion.Euler(new Vector3(0,0,randomRot));
            z += 3;

            if(i <= wallsCount)
            {
                finishLine.transform.position = new Vector3(0,0.02f,z * 2);
            }
        }
    }
}
