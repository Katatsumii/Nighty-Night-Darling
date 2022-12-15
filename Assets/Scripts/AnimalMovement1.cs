using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement1 : MonoBehaviour
{
    float moveSpeed = 6f;
    float movementInputDirection;
    float jumpForce = 8f;
    

    bool isGrounded;
    bool isJumping;
    bool isFacingRight = true;
   public  bool isWalking;

    float jumpTimeCounter;
    public float jumpTime;
    
    public LayerMask whatIsGround;
    public Transform jumpCheck;
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
        Physics2D.IgnoreLayerCollision(11, 9, true);
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();


    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurrondings();
    }

    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (isGrounded&&Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            anim.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter>0)
            {
                anim.SetTrigger("Jump");
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter-=Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
   
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
    void CheckSurrondings()
    {
        isGrounded = Physics2D.OverlapCircle(jumpCheck.position, jumpCheckRadius, whatIsGround);
    }
    void UpdateAnimations()
    {
        anim.SetBool("IsWalking",isWalking);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.CompareTag("House"))
        {
            loader.LoadScene(9);
        }

    }
}
