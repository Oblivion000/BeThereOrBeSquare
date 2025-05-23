using UnityEngine;

[RequireComponent(typeof(InputManager))]

public class TapSwipeDetection : MonoBehaviour
{
    InputManager inputManager;
    PlayerController playerController;

    //Variables to control Tapping and Swiping
    float distThreshold = 0.5f; //Previously 0.8f
    float dirThreshold = 0.9f; //Previously 0.9f

    float swipeTimeout = 0.5f; //The lower the timeout, the less time there is for a swipe to occur.
    float tapTimeout = 0.2f; //Same as above but for Tap.

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

        playerController = FindFirstObjectByType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene");
        }
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
        float distance = Vector2.Distance(startPos, endPos);
        if (distance < distThreshold) //not a valid swipe
        {
            return;
        }

        Vector2 dir = (endPos - startPos).normalized;
        float checkUp = Vector2.Dot(Vector2.up, dir);
        float checkLeft = Vector2.Dot(Vector2.left, dir);

        if (checkUp >= dirThreshold)
        {
            Debug.Log("Swipe Up");
            playerController.HandleJump();
            return;
        }
       if (checkUp <= -dirThreshold)
        {
            Debug. Log("Swipe Down");
            playerController.FastDescend();
        }
       if (checkLeft >= dirThreshold)
        {
            Debug.Log("Swipe Left");
            return;
        }
        if (checkLeft <= -dirThreshold)
        {
            Debug.Log("Swipe Right");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
