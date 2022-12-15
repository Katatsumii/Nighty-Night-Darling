using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallonScript : MonoBehaviour
{
    public bool redBaloonDestroyed = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetTrigger("Bum");
        }
    }
    void BaloonBum()
    {
        redBaloonDestroyed = true;
    }
    void DestroyBaloon()
    {

        Destroy(gameObject);
    }
}