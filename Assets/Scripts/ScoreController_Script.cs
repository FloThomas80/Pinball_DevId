using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController_Script : MonoBehaviour
{
    private static ScoreController_Script instance;

    private int score;
    public int Score => score;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    public static ScoreController_Script Instance //instance call
    {
        get 

        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreController_Script>();

                if (instance == null)
                {
                    GameObject scoreManagerObject = new GameObject("ScoreManager");
                    instance = scoreManagerObject.AddComponent<ScoreController_Script>();
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this) //singleton, only one instance exist ?
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);//don't destroy me ! i'm THE SCORE !
    }
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
}
