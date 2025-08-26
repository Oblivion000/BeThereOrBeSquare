using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // UI Text for current score
    public TextMeshProUGUI highScoreText;   // UI Text for high score
    public TextMeshProUGUI gameOverScore;

    private float score = 0f;
    private int highScore = 0;

    private void Start()
    {
        // Load high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void Update()
    {
        // Increase score over time, scaled by the current SpeedManager multiplier
        float multiplier = SpeedManager.Instance != null ? SpeedManager.Instance.GetMultiplier() : 1f;
        score += Time.deltaTime * 10f * multiplier;

        // Update UI
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        gameOverScore.text = "Score: " + Mathf.FloorToInt(score).ToString();

        // Update high score if beaten
        if (score > highScore)
        {
            highScore = Mathf.FloorToInt(score);
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    
    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}


