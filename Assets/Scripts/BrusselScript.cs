using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrusselScript : MonoBehaviour
{
    CircleCollider2D coll;
    Rigidbody2D rb;
    Transform doorPosition;
    Animator anim;
    float flySpeed;
    AnimalMovement2 kotel;
    
    private void Awake()
    {   
        coll = GetComponent<CircleCollider2D>();
        flySpeed = Random.Range(2f, 5f);
        doorPosition = GameObject.FindGameObjectWithTag("Doors").GetComponent<Transform>();
        anim=GetComponent<Animator>(); 
        rb= GetComponent<Rigidbody2D>();
        kotel=GameObject.FindWithTag("Player").GetComponent<AnimalMovement2>();
        Physics2D.IgnoreLayerCollision(7, 3,true);

    }

    // Update is called once per frame
    void Update()
    {
        var step = flySpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, doorPosition.position, step);
        Physics2D.IgnoreLayerCollision(7, 8);
    }
  //  private void OnCollisionEnter2D(Collision2D collision)
   // {  
        //if (collision.gameObject.CompareTag("Player"))
       // {
       //     anim.SetTrigger("Bum");
            
       // }
  //  }
    
    
    private void dead()
    {
        
        Destroy(gameObject);
    }
    private void disableCollider()
    {
        
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Bum();
        }
    }
    public void Bum()
    {
        
        anim.SetTrigger("Bum");
    }
    public void killedEnemies()
    {
        kotel.killedEnemies++;
    }
    
}