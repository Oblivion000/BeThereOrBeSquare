using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; }

    private float baseMultiplier = 1f;
    private float currentMultiplier = 1f;

    private List<Coroutine> activeBoosts = new List<Coroutine>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public float GetMultiplier()
    {
        return currentMultiplier;
    }

    public void ActivateBoost(float boostMultiplier, float duration)
    {
        // Apply the new boost
        currentMultiplier *= boostMultiplier;

        // Start a coroutine to remove it later
        Coroutine c = StartCoroutine(RemoveBoostAfterTime(boostMultiplier, duration));
        activeBoosts.Add(c);
    }

    private IEnumerator RemoveBoostAfterTime(float boostMultiplier, float duration)
    {
        yield return new WaitForSeconds(duration);

        // Remove the boost effect
        currentMultiplier /= boostMultiplier;

        // Remove coroutine from active list
        activeBoosts.RemoveAll(x => x == null);
    }
}
