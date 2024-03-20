using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float coyoteTime = 0.1f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float fallingSpeed = 2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool isJumping;
    private float jumpTimeCounter;

    [SerializeField] private AudioClip jumpSoundClip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Coyote Time: Allow jumping shortly after leaving the ground
        if (isGrounded)
        {
            jumpTimeCounter = coyoteTime;
        }
        else
        {
            jumpTimeCounter -= Time.deltaTime;
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpTimeCounter > 0) && !PauseMenu.isPaused)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpTimeCounter = 0;
            SoundFXManager.instance.PlaySoundFXCLip(jumpSoundClip, transform, 1f);
        }

        // Variable Jump Height: Allow higher jumps by holding the jump button
        if (Input.GetButtonUp("Jump") && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
            isJumping = false;
        }
        if (rb.velocity.y < 0 && !isGrounded)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallingSpeed - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on movement direction
        if (horizontalInput > 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(2f, 2f, 1f); // Facing right
        }
        else if (horizontalInput < 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f); // Facing Left
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
