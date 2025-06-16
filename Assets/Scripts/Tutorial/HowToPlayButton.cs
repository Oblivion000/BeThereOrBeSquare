using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject howToPlayPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInstructions()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        howToPlayPanel.SetActive(false);
    }

    public void ToggleInstructions()
    {
        howToPlayPanel.SetActive(!howToPlayPanel.activeSelf);
    }
}
