using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply boost
            SpeedManager.Instance.ActivateBoost(boostMultiplier, boostDuration);

            // Return to pool
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


