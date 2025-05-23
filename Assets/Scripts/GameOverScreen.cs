using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPanel; // Assign in the Inspector
    public SoundManager SoundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameOverPanel == null)
        {
            Debug.LogError("Checkpoint Panel is not assiged in the Inspector!");
        }
        HideGameOverPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        Debug.Log("GameOverScreen being called.");
        SoundManager.StopMusic();
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
}
