using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Pools")]
    public ObjectPool obstaclePool;
    public ObjectPool pickupPool;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 2.5f;

    [Header("Obstacle Settings")]
    public float obstacleBaseSpeed = 5f;

    [Header("Pickup Settings")]
    public float pickupBaseSpeed = 5f;
    [Range(0f, 1f)] public float pickupChance = 0.2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float speedMultiplier = SpeedManager.Instance != null ? SpeedManager.Instance.GetMultiplier() : 1f;

            // Random delay scaled by current speed multiplier
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay) / speedMultiplier;
            yield return new WaitForSeconds(delay);

            bool spawnPickup = Random.value < pickupChance;

            GameObject obj;
            if (spawnPickup)
            {
                obj = pickupPool.GetObstacle(spawnPoint.position);
                ObstacleMovement move = obj.GetComponent<ObstacleMovement>();
                if (move != null) move.SetSpeed(pickupBaseSpeed * speedMultiplier);
            }
            else
            {
                obj = obstaclePool.GetObstacle(spawnPoint.position);
                ObstacleMovement move = obj.GetComponent<ObstacleMovement>();
                if (move != null) move.SetSpeed(obstacleBaseSpeed * speedMultiplier);
            }
        }
    }
}






