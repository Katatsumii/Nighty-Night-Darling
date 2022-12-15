using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBaloonScript : MonoBehaviour
{
    public bool blueBaloonDestroyed = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetTrigger("Bum");
        }
    }
    void BaloonBum()
    {
        blueBaloonDestroyed = true;
    }
    void DestroyBaloon()
    {
        
        Destroy(gameObject);
    }
}
