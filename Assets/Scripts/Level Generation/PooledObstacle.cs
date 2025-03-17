using UnityEngine;

public class PooledObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DespawnZone"))
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        ObjectPool pool = FindFirstObjectByType<ObjectPool>(); // Locate pool manager
        if (pool != null)
        {
            pool.ReturnToPool(gameObject);
        }
        else
        {
            Debug.LogWarning("ObjectPool not found!");
            gameObject.SetActive(false); // Fallback
        }
    }
}



