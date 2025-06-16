using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float lifetime = 1.5f; // Time before the object is destroyed
    public float fadeDuration = 0.5f; // Duration of the fade effect

    private SpriteRenderer sr;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Start fading when nearing end of life
        if (timer > lifetime - fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (timer - (lifetime - fadeDuration)) / fadeDuration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }

        if (timer >= lifetime)
        {
            Destroy(gameObject); // Destroy the object after its lifetime
        }
    }
}
