using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement3 : MonoBehaviour
{
    float moveSpeed =5f;
    float movementInputDirection;
    [SerializeField]
    float jumpForce = 12f;
    public EdgeCollider2D platform;
    bool isGrounded; 
    public bool isFacingRight = true;
   public  bool isWalking;
    bool canJump = true;

    float jumpCounter;
    float jumpTime = 0.2f;
    float jumpBufferLenghth = 0.1f;
    float jumpBufferCount;
    float waitTime;

    public LayerMask whatIsGround;
    public LayerMask whatIsFurniture;
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
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckIfCan();
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
        if (Input.GetButtonDown("Jump"))
        {
            
            jumpBufferCount = jumpBufferLenghth;
            Jump();
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
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
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);
    }
    void Jump()
    {
        if (canJump)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }
    }
    void CheckSurrondings()
    {
        isGrounded = Physics2D.OverlapCircle(jumpCheck.position, jumpCheckRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(jumpCheck.position, jumpCheckRadius, whatIsFurniture);
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
            loader.LoadScene(4);
        }

    }
    IEnumerator fall()
    {
        Physics2D.IgnoreLayerCollision(3, 9, true);
        platform.usedByEffector = false;
        yield return new  WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(3, 9, false);
        platform.usedByEffector = true;


    }
}
