using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    private int extraJump;
    [SerializeField] private int extraJumpValue;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        JumpCheck();
        HandleJumping();
    }

    void FixedUpdate()
    {
        if(isGrounded)
            animator.SetBool("isOnGround", true);
        else animator.SetBool("isOnGround", false);
        HandleMovement();
    }

    // Script for movement
    void HandleMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Start the animation
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        // Flip when change direction
        if(!facingRight && moveInput > 0)
            Flip();
        else if (facingRight && moveInput < 0)
            Flip();
    }

    // Scipts for flip
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    // Check whether or not that player is on ground
    void JumpCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Script for jump
    void HandleJumping()
    {
        // Reset extraJump when player landed
        if(isGrounded)
        {
            extraJump = extraJumpValue;
            animator.SetFloat("doubleJump", extraJump);
            animator.SetBool("isJumping", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            animator.SetFloat("doubleJump", extraJump);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded)
            rb.velocity = Vector2.up * jumpForce;
    }
}
