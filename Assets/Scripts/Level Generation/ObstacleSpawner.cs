using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPool objectPool;  // Reference to the object pool
    public Transform spawnPoint;
    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 2.5f;
    public float obstacleSpeed = 5f;
    //public float baseSpawnRate = 1.0f;

    private void Start()
    {
        //spawnRate = baseSpawnRate;
        StartCoroutine(SpawnObstacles());
    }

    private System.Collections.IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            GameObject obstacle = objectPool.GetObstacle(spawnPoint.position);

            // Give it movement
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(-obstacleSpeed, 0);
            }
        }
    }
}



