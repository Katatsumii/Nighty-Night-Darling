using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public CutScri cutscri;
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject paw;
    AnimalMovement2 kotel;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
         kotel = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimalMovement2>();

    }
    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                anim.SetTrigger("Attack");
            }


            timeBtwAttack = startTimeBtwAttack;

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void Attack()
    {
        CutScri projectile = Instantiate(cutscri, paw.transform.position, transform.rotation);
    }
   
}
