using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPanel; // Assign in the Inspector
    public SoundManager SoundManager;
    public TextMeshProUGUI earnedCurrencyText; // UI Text to display earned currency

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameOverPanel == null)
        {
            Debug.LogError("GameOver Panel is not assiged in the Inspector!");
        }
        HideGameOverPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ShowGameOverPanel()
    //{
    //    Time.timeScale = 0;
    //    gameObject.SetActive(true);
    //    Debug.Log("GameOverScreen being called.");
    //    SoundManager.StopMusic();

    //    //Currency awarded here
    //    ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
    //    if (scoreManager != null)
    //    {
    //        int score = scoreManager.GetScore();
    //        int earned = CalculateCurrency(score);
    //        CurrencyManager.Instance.AddCurrency(earned);
    //        earnedCurrencyText.text = "+" + earned.ToString() + " Coins";

    //        Debug.Log($"Currency awarded: {earned}. Total currency: {CurrencyManager.Instance.GetCurrency()}");
    //    }

    //}

    public void ShowGameOverPanel()
    {
        Debug.Log("GameOverScreen being called.");

        //Handle rewards BEFORE freezing time
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            int score = scoreManager.GetScore();
            int earned = CalculateCurrency(score);

            if (CurrencyManager.Instance != null)
            {
                CurrencyManager.Instance.AddCurrency(earned);
            }

            if (earnedCurrencyText != null)
            {
                earnedCurrencyText.text = "+" + earned.ToString() + " Gems";
            }
        }

        //Freeze time AFTER all updates
        Time.timeScale = 0f;

        //Show the panel
        gameObject.SetActive(true);
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void HideGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            Debug.Log("GameOverPanel deactivated!");
            GameOverPanel.SetActive(false);
            Time.timeScale = 1f; // Resume the game
            SoundManager.PlayMusic();
            
        }
    }

    private int CalculateCurrency(int score)
    {
        return Mathf.Max(1, Mathf.FloorToInt(score * 0.1f));
    }

}
