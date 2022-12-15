using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniEyeScript : MonoBehaviour
{
    Animator anim;
    CircleCollider2D coll;
    Rigidbody2D rb;
    Transform doorPosition;
    float flySpeed;
    bool isFacingRight = false;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        flySpeed = Random.Range(1, 5);
        doorPosition = GameObject.FindGameObjectWithTag("Doors").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rb.position.x<0 &&!isFacingRight)
        {
            flip();
        }
        var step = flySpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, doorPosition.position, step);

        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(7, 3);


    }
    void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetTrigger("Bum");
        }
    }
    private void dead()
    {
        Destroy(gameObject);
    }
    private void disableCollider()
    {
        coll.enabled = false;
    }
}
