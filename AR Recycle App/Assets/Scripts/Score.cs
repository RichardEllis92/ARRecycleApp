using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int totalScore = 0;
    public static Score instance;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
        scoreText.text = "Score:" + totalScore.ToString();
    }

    public void AddScore(int gameScore)
    {
        totalScore += gameScore;
        scoreText.text = "Score:" + totalScore.ToString();
    }
    
}
