using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpForce = 10f;
    public float hoverTime = 1.5f;
    public float hoverGravityScale = 0.5f;
    public float fastDropSpeed = 20f;
    private float hoverTimer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float defaultGravity;

    //[Header("Visual Effects")]
    //public GameObject hoverEffect;

    public GameOverScreen GameOverScreen;
    public bool isDead = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;

        SoundManager.Instance.PlayMusic();

        ApplyEquippedSkin();
    }

    private void Update()
    {

    }

    public void HandleJump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;

            if (SoundManager.Instance != null && SoundManager.Instance.jumpSFX != null)
            {
                SoundManager.Instance.sfxSource.PlayOneShot(SoundManager.Instance.jumpSFX);
                Debug.Log("Jump sound played.");
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //To be refactored into taking damage and then the gameover screen after death

            //GameOverScreen.ShowGameOverPanel();
            //SoundManager.Instance.StopMusic();

            Die();

        }
    }


    public void FastDescend()
    {

       rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fastDropSpeed);
    }


    void ApplyEquippedSkin()
    {
        if (SkinManager.Instance != null && SkinManager.Instance.equippedSkin != null)
        {
            var skin = SkinManager.Instance.equippedSkin;
            var animator = GetComponent<Animator>();

            if (animator != null && skin.animatorController != null)
            {
                animator.runtimeAnimatorController = skin.animatorController;
                Debug.Log("Equipped skin applied: " + skin.skinName);
            }
            else
            {
                Debug.LogWarning("Animator missing or skin has no controller!");
            }
        }
        else
        {
            Debug.Log("No skin equipped — using default visuals.");
        }
    }

    public void Die() //Function that will handle disabling player interaction plus call for Death animation
    {
        if (isDead)
                return;
        isDead = true;

        SoundManager.Instance.sfxSource.PlayOneShot(SoundManager.Instance.deathSFX);

        rb.linearVelocity = Vector2.zero;
        rb.simulated = false; //This stops physics updates

        // Play a death sound
        //if (SoundManager.Instance != null && SoundManager.Instance.deathSFX != null)
        //{
        //    SoundManager.Instance.sfxSource.PlayOneShot(SoundManager.Instance.deathSFX);
        //}

        // Spawn particles
        //if (deathEffect != null)
        //{
        //    Instantiate(deathEffect, transform.position, Quaternion.identity);
        //}

        // Hide sprite or delay before hiding
        StartCoroutine(HandleDeathSequence());

    }

    private IEnumerator HandleDeathSequence()
    {
        // Stop score counting
        var scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager != null)
            scoreManager.StopCounting();

        //animator.SetTrigger("Die"); For use after implementation of Death animation

        yield return new WaitForSeconds(2); //An optional delay allowing for animations to play

        GetComponent<SpriteRenderer>().enabled = false; //Used to disable the Sprite visual of the player

        GameOverScreen.ShowGameOverPanel(); //Call for the ShowGameOverPanel function.

        SoundManager.Instance.StopMusic(); //Calling the StopMusic Function from the SoundManager.

    }
}

