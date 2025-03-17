using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

