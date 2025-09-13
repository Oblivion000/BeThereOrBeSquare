using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveUpSpeed = 50f;
    public float fadeDuration = 1.5f;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private float timer;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show(string message)
    {
        GetComponent<TextMeshProUGUI>().text = message;
        canvasGroup.alpha = 1f;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Move up
        rectTransform.anchoredPosition += Vector2.up * moveUpSpeed * Time.deltaTime;

        // Fade out
        canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        // Destroy when finished
        if (timer >= fadeDuration)
            Destroy(gameObject);
    }
}

