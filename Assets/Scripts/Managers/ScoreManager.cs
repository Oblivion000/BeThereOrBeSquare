using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // UI Text for current score
    public TextMeshProUGUI highScoreText;   // UI Text for high score
    public TextMeshProUGUI gameOverText;

    private float score = 0f;
    private int highScore = 0;
    public float scoreMultiplier = 1f; // Base multiplier
    public bool isPowerUpActive = false;
    private int powerUpStacks = 0;

    private void Start()
    {
        // Load high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void Update()
    {
        // Increase score over time
        score += Time.deltaTime * 10f * scoreMultiplier;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        gameOverText.text= "Score: " + Mathf.FloorToInt(score).ToString();

        // Update high score if beaten
        if (score > highScore)
        {
            highScore = Mathf.FloorToInt(score);
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void ActivateSpeedBoost(float boostMultiplier, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(boostMultiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float boostMultiplier, float duration)
    {
        // Activate boost
        isPowerUpActive = true;
        scoreMultiplier = boostMultiplier;

        // SpeedManager also reacts
        SpeedManager.Instance.SetMultiplier(boostMultiplier);

        yield return new WaitForSeconds(duration);

        // Reset
        isPowerUpActive = false;
        scoreMultiplier = 1f;
        SpeedManager.Instance.SetMultiplier(1f);
    }

    // Call this when power-up is collected
    //public void ActivatePowerUp(int stackLevel)
    //{
    //    isPowerUpActive = true;
    //    powerUpStacks = Mathf.Clamp(stackLevel, 1, 3); // Max 3 stacks

    //    // Increase score multiplier based on power-up stacks
    //    scoreMultiplier = 1f + (powerUpStacks * 0.5f); // 1.5x, 2x, 2.5x
    //}

    //// Call this when power-up ends
    //public void DeactivatePowerUp()
    //{
    //    isPowerUpActive = false;
    //    powerUpStacks = 0;
    //    scoreMultiplier = 1f; // Reset multiplier
    //}

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}

