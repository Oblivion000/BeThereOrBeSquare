using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;  // Power-up prefab to spawn
    public Transform spawnArea;  // The area where power-ups can spawn
    //public float spawnRate = 5f;  // Time between spawns (seconds)
    public float powerUpDuration = 5f;  // Duration of the power-up effect
    public float powerUpSpawnChance = 0.2f;  // Chance to spawn a power-up each time
    public float minSpawnRate = 2f;  // Minimum time between spawns (seconds)
    public float maxSpawnRate = 5f;  // Maximum time between spawns (seconds)
    public float powerUpSpeed = 5f;

    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Randomize the spawn rate between the min and max spawn rates
            float randomSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(randomSpawnRate);

            // Randomly decide if we should spawn a power-up
            if (Random.value <= powerUpSpawnChance)
            {
                SpawnPowerUp();
            }
        }
    }

    private void SpawnPowerUp()
    {
        // Spawn the power-up at the spawner's position
        Vector3 spawnPosition = transform.position;

        // Instantiate the power-up at the spawn position
        GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

        // Set the power-up speed (you can adjust it based on your game speed or power-up multiplier)
        powerUp.GetComponent<PowerUpMovement>().speed = powerUpSpeed;
    }
}

