using TMPro;
using UnityEngine;

public class CurrencyDiplayUI : MonoBehaviour
{
    public TextMeshProUGUI currencyText; // UI Text to display currency
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCurrencyDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCurrencyDisplay()
    {
        if (currencyText != null && CurrencyManager.Instance != null)
        {
            int totalCurrency = CurrencyManager.Instance.GetCurrency();
            currencyText.text = "Gems: " + totalCurrency.ToString();
        }
    }
}
