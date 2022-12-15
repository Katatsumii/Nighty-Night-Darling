using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBaloonScript : MonoBehaviour
{
    public bool yellowBaloonDestroyed = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)   
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetTrigger("Bum");
        }
    }
    void BaloonBum()
    {
        yellowBaloonDestroyed = true;
    }
    void DestroyBaloon()
    {

        Destroy(gameObject);
    }
}