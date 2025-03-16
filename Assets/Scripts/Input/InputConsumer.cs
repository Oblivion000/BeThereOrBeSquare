using UnityEngine;

[RequireComponent(typeof(InputManager))]

public class InputConsumer : MonoBehaviour
{
    InputManager inputManager;

    //Variables to control Tapping and Swiping
    float distThreshold = 0.8f;
    float dirThreshold = 0.9f;

    float swipeTimeout = 0.5f;
    float tapTimeout = 0.1f;

    Vector2 startPos;
    Vector2 endPos;
    float startTime;
    float endTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        inputManager.OnTouchBegin += TouchStarted;
        inputManager.OnTouchEnd += TouchEnded;
    }

    void TouchStarted()
    {
        startPos = inputManager.PrimaryPosition();
        startTime = Time.time;

    }

    void TouchEnded()
    {
        endPos = inputManager.PrimaryPosition();
        endTime = Time.time;
        DetectInput();
    }

    void DetectInput()
    {
        float totalTime = endTime - startTime;
        if (totalTime > swipeTimeout)
        {
            Debug.Log("Not a tap or a swipe");
            return;
        }
        if (totalTime < tapTimeout)
        {
            Tap();
            return;
        }

        CheckSwipe();
    }

    void Tap()
    {
        Debug.Log("Tap happened");
    }   

    void CheckSwipe()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
