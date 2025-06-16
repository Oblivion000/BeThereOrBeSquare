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
            //OnPlayerDeath();
            GameOverScreen.ShowGameOverPanel();
            SoundManager.StopMusic();

        }
    }


    public void FastDescend()
    {

       rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fastDropSpeed);
    }

    //On Death animation Test
    public void OnPlayerDeath()
    {
        Vector3 origin = transform.position;
        Vector2 size = GetComponent<SpriteRenderer>().bounds.size;

        //this is to spawn a grid of small cubes
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    Vector3 offset = origin + new Vector3(
                        (x - gridSize / 2) * (size.x + cubeSpacing),
                        (y - gridSize / 2) * (size.y + cubeSpacing)
                        );

                    GameObject cube = Instantiate(deathAnimationPrefab, origin + offset, Quaternion.identity);
                    Rigidbody2D rbCube = cube.GetComponent<Rigidbody2D>();

                    Vector2 explosionDirection = (cube.transform.position - origin).normalized;
                    rbCube.AddForce(explosionDirection * explosionForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}

