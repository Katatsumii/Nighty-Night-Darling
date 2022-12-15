using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAwayScript : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public float force = 1;

    private void Start()
    {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
    }

    public void FlyAway()
    {
        anim.SetTrigger("FlyAway");
        rb.velocity=new Vector2 (5f,-2f);
    }
}