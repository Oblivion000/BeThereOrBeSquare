using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    public event Action<int> OnCurrencyChanged;

    private int currency = 0;
    private const string CurrencyKey = "PlayerCurrency";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadCurrency();
    }

    private void LoadCurrency()
    {
        currency = PlayerPrefs.GetInt(CurrencyKey, 0);
    }

    private void SaveCurrency()
    {
        PlayerPrefs.SetInt(CurrencyKey, currency);
        PlayerPrefs.Save();
    }

    public int GetCurrency()
    {
        return currency;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        SaveCurrency();
        OnCurrencyChanged?.Invoke(currency); //notifies the UI
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            SaveCurrency();
            OnCurrencyChanged?.Invoke(currency); //notifies the UI
            return true;
        }
        return false;
    }
}

