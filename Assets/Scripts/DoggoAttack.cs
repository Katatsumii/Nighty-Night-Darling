using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoAttack : MonoBehaviour
{
    public WoofScript woof;
    public GameObject szczek;
    AnimalMovement piesel;
    Animator anim;
    bool canAttack = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        piesel = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimalMovement>();

    }
    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DogAttackAnimation"))
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
   
         if (Input.GetButtonDown("Fire1")&&canAttack)
           {
                anim.SetTrigger("Attack");
           }
    }
    void Attack()
    {
        WoofScript projectile = Instantiate(woof, szczek.transform.position, transform.rotation);
    }

}
