using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject wallFragment;
    GameObject star;

    GameObject wall1,wall2;

    float rotationZ;
    float rotationZMax = 180;

    void Awake() 
    {
        wallFragment = Resources.Load("WallFragment") as GameObject;
        star = Resources.Load("Star") as GameObject;
    }

    void Start() 
    {
        SpawnWallFragments();
    }

    void SpawnWallFragments()
    {
        rotationZMax = Random.Range(45,180);
        wall1 = new GameObject();
        wall2 = new GameObject();

        wall1.name = "Wall1";
        wall2.name = "Wall2";

        wall1.transform.SetParent(transform);
        wall2.transform.SetParent(transform);

        for(int i = 0; i < 100; i++)
        {
            GameObject Wall = Instantiate(wallFragment , transform.position, Quaternion.Euler(0,0,rotationZ));
            rotationZ += 3.6f;

            if(rotationZ <= rotationZMax)
            {
                Wall.transform.SetParent(wall1.transform);
                Wall.gameObject.tag = "Hit";
            }
            else
            {
                Wall.transform.SetParent(wall2.transform);
                Wall.gameObject.tag = "Fail";
            }
        }

        wall1.transform.localPosition = Vector3.zero;
        wall2.transform.localPosition = Vector3.zero;

        wall1.transform.localRotation = Quaternion.Euler(Vector3.zero);
        wall2.transform.localRotation = Quaternion.Euler(Vector3.zero);

        GameObject wallFragmentChild = wall1.transform.GetChild(wall1.transform.childCount / 2).gameObject;
        AddStar(wallFragmentChild);
    }

    void AddStar(GameObject wallFragmentChild)
    {
        GameObject s = Instantiate(star,transform.position,Quaternion.identity);
        s.transform.SetParent(wallFragmentChild.transform);
        s.transform.localPosition = new Vector3(0.05f,0.75f,-0.06f);
    }
}
