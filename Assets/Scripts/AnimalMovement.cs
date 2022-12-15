using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float movementInputDirection;
    float jumpForce = 12f;

    bool isGrounded;
    bool isFacingRight = true;
   public  bool isWalking;
    bool canJump = true;

    float jumpCounter;
    float jumpTime = 0.2f;
    float jumpBufferLenghth = 0.1f;
    float jumpBufferCount;

    public WoofScript woof;
    public LayerMask whatIsGround;
    public Transform jumpCheck;
    public Transform woofPostion;
    public float jumpCheckRadius;
    public float killedEnemies;

    LoadingScreenScript loader;
    Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        loader=GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckIfCan();
        UpdateAnimations();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DogAttackAnimation"))
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = 5f;
        }

    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurrondings();
    }

    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

      
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
    }
    void CheckMovementDirection()
    {
        if (movementInputDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movementInputDirection < 0 && isFacingRight)
        {
            Flip();
        }
        if (movementInputDirection != 0 && rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);
    }
    void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }
    }
    void CheckSurrondings()
    {
        isGrounded = Physics2D.OverlapCircle(jumpCheck.position, jumpCheckRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCounter = jumpTime;
        }

        else
        {
            jumpCounter -= Time.deltaTime;
        }
    }
    void CheckIfCan()
    {
        if (jumpBufferCount >= 0 || jumpCounter > 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
    void UpdateAnimations()
    {
        anim.SetBool("IsWalking",isWalking);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.CompareTag("House"))
        {
            loader.LoadScene(7);
        }

    }
   
}
