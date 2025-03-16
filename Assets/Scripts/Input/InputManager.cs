using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls input;

    public event System.Action OnTouchBegin;
    public event System.Action OnTouchEnd;

    private void Awake()
    {
        input = new PlayerControls();
    
    }

    private void OnEnable()
    {
        input.Enable();
        input.Base.Touch.started += ctx => OnTouchBegin();
        input.Base.Touch.canceled += ctx => OnTouchEnd();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Base.Touch.started -= ctx => OnTouchBegin();
        input.Base.Touch.canceled -= ctx => OnTouchEnd();
    }
    public Vector2 PrimaryPosition()
    {
        Vector2 touchPos = input.Base.PrimaryPosition.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
