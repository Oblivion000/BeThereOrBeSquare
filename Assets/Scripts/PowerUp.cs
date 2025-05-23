using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f; // Duration of the power-up effect
    public float multiplier = 2f; // Speed multiplier when the power-up is activated

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DespawnZone"))
        {
            Destroy(gameObject); // Destroy the power-up when the it collides with the despawn zone.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assuming the player has a "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            //ActivatePowerUp(other.gameObject);
            Destroy(gameObject); // Destroy the power-up after it’s collected
        }
    }



    //private void ActivatePowerUp(GameObject player)
    //{
    //    // Get the ScoreManager from the player
    //    ScoreManager scoreManager = player.GetComponent<ScoreManager>();

    //    if (scoreManager != null)
    //    {
    //        scoreManager.ActivatePowerUp(1); // Activating power-up with stack level 1 (can be adjusted for more stacks if needed)
    //    }

    //    // Get the ObstacleSpawner component from the scene
    //    ObstacleSpawner obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    //    if (obstacleSpawner != null)
    //    {
    //        obstacleSpawner.ActivatePowerUp(duration); // Activate power-up for obstacles (adjusting speed and spawn rate)
    //    }

    //    //Optional: You can add sound effects or animations here if needed
    //    //For example, play sound or particle effect:
    //     //PlayPowerUpSound();
    //    //PlayPowerUpAnimation();
    //}
}

