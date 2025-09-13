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


    //For Death Animation
    public GameObject deathAnimationPrefab;
    public int gridSize = 3; // Number of cubes in each direction
    public float cubeSpacing = 0.1f; // Spacing between cubes
    public float cubeSize = 0.1f; // Size of each cube
    public float explosionForce = 200f; // Force applied to cubes on explosion


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
            //OnPlayerDeath();
            GameOverScreen.ShowGameOverPanel();
            SoundManager.Instance.StopMusic();

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
}

