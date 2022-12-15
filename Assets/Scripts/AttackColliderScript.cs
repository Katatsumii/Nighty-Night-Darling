using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderScript : MonoBehaviour
{
    public float killedEnemies;

    private void OnTriggerEnter2D(Collider2D collision)
      
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
        killedEnemies++;
        }
    }
}
    
        
    
   
    
