using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControllerCopy : MonoBehaviour
{

    private int score;
    public int Score => score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

  
    public void IncreaseScore(int value) //update Score
    {
        score += value;
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

    public void ResetScore() //reset score to zero
    {
        score = 0;
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

    public int GetScrore() //get the score
    {
        return score;
    }
}
