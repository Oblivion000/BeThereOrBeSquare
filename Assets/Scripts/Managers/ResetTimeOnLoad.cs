using UnityEngine;

public class ResetTimeOnLoad : MonoBehaviour
{

    void Awake()
    {
            Time.timeScale = 1f; // Always unfreeze time when entering this scene
    }
}
