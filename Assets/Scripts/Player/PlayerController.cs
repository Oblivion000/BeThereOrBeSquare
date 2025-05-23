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
    public SoundManager SoundManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
        //hoverEffect.SetActive(false);
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
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canHover)
        //{
        //    isHovering = true;
        //    hoverTimer = hoverTime;
        //    rb.gravityScale = hoverGravityScale;
        //    hoverEffect.SetActive(true);
        //}

        //if (isHovering)
        //{
        //    hoverTimer -= Time.deltaTime;
        //    if (hoverTimer <= 0)
        //    {
        //        isHovering = false;
        //        rb.gravityScale = defaultGravity;
        //        hoverEffect.SetActive(false);
        //        canHover = false;
        //    }
        //}

        //if (Input.GetKeyUp(KeyCode.Space) && isHovering)
        //{
        //    isHovering = false;
        //    rb.gravityScale = defaultGravity;
        //    hoverEffect.SetActive(false);
        //    canHover = false;
        //}
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
            GameOverScreen.ShowGameOverPanel();
            SoundManager.StopMusic();

        }
    }


    public void FastDescend()
    {

       rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fastDropSpeed);
    }

}

