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
    public static ScoreController_Script Instance
    {
        get
        {
            // If the instance is null, find the existing instance or create a new one
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreController_Script>();

                // If no instance exists in the scene, create a new GameObject with the ScoreManager component
                if (instance == null)
                {
                    GameObject scoreManagerObject = new GameObject("ScoreManager");
                    instance = scoreManagerObject.AddComponent<ScoreController_Script>();
                }
            }

            return instance;
        }
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of the score manager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Keep the score manager across scene changes
        DontDestroyOnLoad(gameObject);
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
