using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class Trail : MonoBehaviour
{
    TrailRenderer trailRenderer;
    public InputManager inputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trailRenderer.enabled) //ensures that trail Renderer just follows the position
        {
            transform.position = inputManager.PrimaryPosition();
        }
    }

    void EnableTrailRenderer()
    {
        transform.position = inputManager.PrimaryPosition();
       trailRenderer.enabled = true;
    }

    private void DisableTrailRenderer()
    {
        trailRenderer.enabled = false;
    }

    private void OnEnable()
    {
        inputManager.OnTouchBegin += EnableTrailRenderer;
        inputManager.OnTouchEnd += DisableTrailRenderer;
    }

    private void OnDisable()
    {
        inputManager.OnTouchBegin -= EnableTrailRenderer;
        inputManager.OnTouchEnd -= DisableTrailRenderer;
    }
}
