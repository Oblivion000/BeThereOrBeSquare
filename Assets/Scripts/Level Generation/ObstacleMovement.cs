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

        // If off-screen, return to pool
        if (transform.position.x < -20f) // adjust boundary
        {
            var poolRef = GetComponent<PoolReference>();
            if (poolRef != null && poolRef.pool != null)
            {
                poolRef.pool.ReturnToPool(gameObject);
            }
            else
            {
                // fallback if pool wasn't set
                gameObject.SetActive(false);
            }
        }
    }
}



