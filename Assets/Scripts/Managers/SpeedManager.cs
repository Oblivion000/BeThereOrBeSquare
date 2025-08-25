using UnityEngine;
using System.Collections;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance;

    [Header("Base Settings")]
    public float speedMultiplier = 1f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // avoid duplicates
    }

    public void ActivateBoost(float multiplier, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(BoostRoutine(multiplier, duration));
    }

    private IEnumerator BoostRoutine(float multiplier, float duration)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        speedMultiplier = 1f;
    }

    public float GetMultiplier()
    {
        return speedMultiplier;
    }

    public void SetMultiplier(float value) => speedMultiplier = value; // optional, direct setter
}


