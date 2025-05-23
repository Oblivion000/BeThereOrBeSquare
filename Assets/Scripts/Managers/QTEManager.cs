using UnityEngine;

public class QTEManager : MonoBehaviour
{
    public float qteRealDuration = 3f;  // Real-world seconds
    private float qteTimer;
    private int swipeCount;
    private bool isQTEActive = false;

    void Update()
    {
        if (!isQTEActive) return;

        qteTimer += Time.unscaledDeltaTime;

        if (SwipeDetectedUp())  // <-- Call your existing swipe detection
        {
            swipeCount++;
            Debug.Log($"Swipe #{swipeCount}");
        }

        if (swipeCount >= 3)
        {
            EndQTE(true);
        }
        else if (qteTimer >= qteRealDuration)
        {
            EndQTE(false);
        }
    }

    public void StartQTE()
    {
        isQTEActive = true;
        qteTimer = 0f;
        swipeCount = 0;

        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        // Optional: Show UI prompt
    }

    private void EndQTE(bool success)
    {
        isQTEActive = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        // Optional: Hide UI prompt

        if (!success)
        {
            Debug.Log("QTE failed - apply damage here.");
            // Hook in damage logic later
        }
        else
        {
            Debug.Log("QTE succeeded!");
        }
    }

    private bool SwipeDetectedUp()
    {
        // Call your swipe system and return true if it was an "up" swipe
        return false; // Placeholder
    }
}
