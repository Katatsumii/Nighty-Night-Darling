using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parrotto : MonoBehaviour
{
    public int killedEnemies;
    float movementInputDirection, movementInputHigh;
    public float speedHorizontal = 10f, speedVertical = 8f;
    Rigidbody2D rb;
    Animator anim;
    LoadingScreenScript loading;

    bool isFacingRight = true;
    bool isFlying;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        loading = GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovementDirection();
        CheckInput();
        AnimatorPlayer();
        AnimationChecks();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
    }
    void ApplyMovement()
    {
        rb.velocity = new Vector2(speedHorizontal * movementInputDirection * Time.deltaTime, speedVertical * movementInputHigh * Time.deltaTime);
    }
    void CheckMovementDirection()
    {
        if (movementInputDirection>0&&!isFacingRight)
        {
            Flip();
        }
        else if(movementInputDirection<0&&isFacingRight)
        {
            Flip();
        }
    }
    void AnimationChecks()
    {
        if (movementInputDirection != 0 && rb.velocity.x != 0)
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;   
        }


    }

    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        movementInputHigh = Input.GetAxisRaw("Vertical");

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);
    }
    void AnimatorPlayer()
    {

        anim.SetBool("IsFlying", isFlying);
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { if (collision.gameObject.CompareTag("Enemy"))
        {
            killedEnemies++;
        }
      if(collision.gameObject.CompareTag("House"))
        {
            loading.LoadScene(3);
        }
    }
}
