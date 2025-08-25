using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float baseSpeed = 0f; // Base speed without multiplier

    // Set the base speed (the "normal" speed for this obstacle)
    public void SetSpeed(float newSpeed)
    {
        baseSpeed = newSpeed;
    }

    private void Update()
    {
        // Get current speed multiplier from SpeedManager
        float multiplier = SpeedManager.Instance != null ? SpeedManager.Instance.GetMultiplier() : 1f;

        // Move left using base speed scaled by multiplier
        transform.position += Vector3.left * baseSpeed * multiplier * Time.deltaTime;

        // Off-screen pooling
        if (transform.position.x < -20f) // adjust boundary as needed
        {
            var poolRef = GetComponent<PoolReference>();
            if (poolRef != null && poolRef.pool != null)
            {
                poolRef.pool.ReturnToPool(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}






