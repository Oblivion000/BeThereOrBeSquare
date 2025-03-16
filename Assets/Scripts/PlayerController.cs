using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpForce = 10f;
    public float hoverTime = 1.5f;
    public float hoverGravityScale = 0.5f;
    private float hoverTimer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isHovering;
    private bool canHover;
    private float defaultGravity;

    [Header("Visual Effects")]
    public GameObject hoverEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
        hoverEffect.SetActive(false);
    }

    private void Update()
    {
        HandleJump();
        HandleDuck();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            canHover = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canHover)
        {
            isHovering = true;
            hoverTimer = hoverTime;
            rb.gravityScale = hoverGravityScale;
            hoverEffect.SetActive(true);
        }

        if (isHovering)
        {
            hoverTimer -= Time.deltaTime;
            if (hoverTimer <= 0)
            {
                isHovering = false;
                rb.gravityScale = defaultGravity;
                hoverEffect.SetActive(false);
                canHover = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isHovering)
        {
            isHovering = false;
            rb.gravityScale = defaultGravity;
            hoverEffect.SetActive(false);
            canHover = false;
        }
    }

    void HandleDuck()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Shrink player hitbox, change animation, etc.
        }
        else
        {
            // Reset player hitbox, animation, etc.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

