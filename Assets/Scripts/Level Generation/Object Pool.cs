using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs; // Array of obstacle prefabs
    [SerializeField] private int poolSize = 10; // Number of obstacles to pool
    private Queue<GameObject> obstaclePool = new Queue<GameObject>(); // Queue for pooling

    private void Start()
    {
        // Fill the pool with inactive obstacles
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], transform);
            obj.SetActive(false);
            obstaclePool.Enqueue(obj); // Add to pool
        }
    }

    public GameObject GetObstacle(Vector3 spawnPosition)
    {
        GameObject obstacle;

        if (obstaclePool.Count > 0)
        {
            obstacle = obstaclePool.Dequeue(); // Get from pool
        }
        else
        {
            // Pool is empty, so create a new one (this should rarely happen)
            obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], transform);
        }

        obstacle.transform.position = spawnPosition;
        obstacle.SetActive(true);
        return obstacle;
    }

    public void ReturnToPool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle); // Add back to the pool
    }
}


