using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Score score;

    static float z;

    static Color currentColor;

    MeshRenderer meshRenderer;
    SpriteRenderer splash;

    float speed = 6f;

    bool move;

    void Awake() 
    {
        score = FindObjectOfType<Score>();
        meshRenderer = GetComponent<MeshRenderer>();
        splash = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Start() 
    {
        z = 0;

        move = false;
    }

    void Update() 
    {
        if(Touch.IsPressing() && !GameController.instance.gameOver)
        {
            move = true;
        }

        if(move)
        {
            Ball.z += speed * Time.deltaTime;
        }

        transform.position = new Vector3(0,transform.position.y,Ball.z);

        UpdateColor();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Hit")
        {
            
        }

        if(other.tag == "Star")
        {
            score.score += 100;
        }

        if(other.tag == "ColorBump")
        {
            SetColor(other.GetComponent<ColorBump>().GetColor());
        }

        if(other.tag == "Fail" && !GameController.instance.gameOver)
        {
            StartCoroutine(GameOver());
        }

        if(other.tag == "FinishLine" && !GameController.instance.gameOver)
        {
            StartCoroutine(Finish());
        }
    }

    void UpdateColor()
    {
        meshRenderer.sharedMaterial.color = currentColor;
    }

    public static float GetZ()
    {
        return Ball.z;
    }

    public static Color SetColor(Color color)
    {
        return currentColor = color;
    }

    public static Color GetColor()
    {
        return currentColor;
    }

    IEnumerator GameOver()
    {
        GameController.instance.gameOver = true;

        splash.color = currentColor;
        splash.transform.position = new Vector3(0,0.75f,Ball.z - 0.05f);
        splash.transform.eulerAngles = new Vector3(0,0,Random.value * 360);
        splash.enabled = true;

        meshRenderer.enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        move = false;
        LoadingSystem.instance.LoadLevel("Restart");
        yield break;
    }

    IEnumerator Finish()
    {
        GameController.instance.gameOver = true;
        LoadingSystem.instance.LoadLevel("Restart");
        yield break;
    }
}
