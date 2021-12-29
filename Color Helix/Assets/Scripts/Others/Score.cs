using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;

    public int score , currentScore;

    void Awake() 
    {
        scoreText = GetComponent<Text>();
    }

    void FixedUpdate() 
    {
        scoreText.text = currentScore.ToString();
        if(currentScore != score)
        {
            currentScore += 5;
        }
    }
}
