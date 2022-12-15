using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{   Animator anim;
   Transform doorPosition;
    BoxCollider2D coll;
    float flySpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        doorPosition=GameObject.FindGameObjectWithTag("Doors").GetComponent<Transform>();
        coll=GetComponent<BoxCollider2D>();
        flySpeed = Random.Range(1, 5);

    }

    // Update is called once per frame
    void Update()
    {
        var step =flySpeed* Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, doorPosition.position, step);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Bum");
        }
    }
    void destoryGameObject()
    {
        Destroy (gameObject);
    }
    void disableCollider()
    {
        coll.enabled = false;
    }

}
