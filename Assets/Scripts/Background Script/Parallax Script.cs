using UnityEngine;
using UnityEngine.UI;

public class ParallaxUI : MonoBehaviour
{
    public RectTransform canvas; // Assign your Canvas here
    public float parallaxSpeed = -50f; // UI units (pixels) per second
    private float bgWidth, bgTotalWidth;
    private GameObject bgCloneObj;
    private bool isObjCloned = false;

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();

        // Width of the UI element
        bgWidth = rect.rect.width;
        bgTotalWidth = bgWidth * 2;

        if (!isObjCloned)
        {
            // Clone background to the right
            Vector3 bgClonePosition = new Vector3(
                transform.localPosition.x + bgWidth,
                transform.localPosition.y,
                transform.localPosition.z
            );

            bgCloneObj = Instantiate(gameObject, transform.parent);
            bgCloneObj.transform.localPosition = bgClonePosition;
            bgCloneObj.transform.localScale = transform.localScale;

            // Prevent recursive cloning
            isObjCloned = true;
            Destroy(bgCloneObj.GetComponent<ParallaxUI>());
        }
    }

    void Update()
    {
        float multiplier = 1f;
        if (SpeedManager.Instance != null)
        {
            multiplier = SpeedManager.Instance.GetMultiplier();
        }

        float adjustedParallaxSpeed = parallaxSpeed * multiplier;
        Vector3 movement = new Vector3(Time.deltaTime * adjustedParallaxSpeed, 0, 0);

        transform.localPosition += movement;
        bgCloneObj.transform.localPosition += movement;

        // Recycle when out of view (UI-based)
        if (transform.localPosition.x < -bgWidth)
            ResetPosition(gameObject);

        if (bgCloneObj.transform.localPosition.x < -bgWidth)
            ResetPosition(bgCloneObj);
    }

    void ResetPosition(GameObject obj)
    {
        float resetPositionX = obj.transform.localPosition.x + bgTotalWidth;
        obj.transform.localPosition = new Vector3(
            resetPositionX,
            transform.localPosition.y,
            transform.localPosition.z
        );
    }
}


