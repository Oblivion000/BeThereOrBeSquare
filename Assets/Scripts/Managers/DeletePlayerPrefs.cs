using UnityEngine;

public class DevTools : MonoBehaviour
{

    [SerializeField] bool resetPlayerPrefs = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
#if UNITY_EDITOR
        if (resetPlayerPrefs)
        {
            Debug.Log("PlayerPrefs reset via DevTools.");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
#endif
    }
}
