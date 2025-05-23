using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private const string TutorialKey = "TutorialCompleted";

    [SerializeField] private GameObject tutorialPanel; // Reference to the tutorial panel UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt(TutorialKey, 0) == 0) //Default to 0 if the Tutorial key doesn't exist
        {
            // Show tutorial UI
            ShowTutorial(); //Method to show the tutorial
            PlayerPrefs.SetInt(TutorialKey, 1); // Set the tutorial as completed
            PlayerPrefs.Save(); // Save the PlayerPrefs to persist the change
        }
        else
        {

        }
    }

    void ShowTutorial()
    {
        tutorialPanel.SetActive(true); //Used to show the Tutorial Panel
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
