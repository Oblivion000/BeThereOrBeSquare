using UnityEngine;

public class DevTools : MonoBehaviour
{
    [Header("Dev Options")]
    [SerializeField] private bool resetPlayerPrefs = false;
    [SerializeField] private bool giveStartingCurrency = false;
    [SerializeField] private int startingCurrency = 1000;

    private void Awake()
    {
#if UNITY_EDITOR
        if (resetPlayerPrefs)
        {
            Debug.Log("PlayerPrefs reset via DevTools.");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        if (giveStartingCurrency)
        {
            PlayerPrefs.SetInt("PlayerCurrency", startingCurrency);
            PlayerPrefs.Save();
            Debug.Log($"DevTools: Currency set to {startingCurrency}");
        }
#endif
    }
}
