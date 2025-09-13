using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class BackgroundFitter : MonoBehaviour
{
    public Camera cam; // Assign Main Camera

    void LateUpdate()
    {
        if (cam == null) cam = Camera.main;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, height);
    }
}

