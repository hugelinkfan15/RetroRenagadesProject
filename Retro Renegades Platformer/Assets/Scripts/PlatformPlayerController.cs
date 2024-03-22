using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public Animator animator;

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
           animator.SetBool("IsJumpingAnim", true);
            jumpTimeCounter = 0;
            SoundFXManager.instance.PlaySoundFXCLip(jumpSoundClip, transform, 1f);
        }

        // Variable Jump Height: Allow higher jumps by holding the jump button
        if (Input.GetButtonUp("Jump") && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
            isJumping = false;
             animator.SetBool("IsJumpingAnim", false);
            
        }
        if (rb.velocity.y < 0 && !isGrounded)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallingSpeed - 1) * Time.deltaTime;
        }

        
        

        
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumpingAnim", false);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on movement direction
        if (horizontalInput > 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(2f, 2f, 1f); // Facing right
            animator.SetFloat("Speed", horizontalInput);
        }
        else if (horizontalInput < 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f); // Facing Left
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }
    }

   
}
