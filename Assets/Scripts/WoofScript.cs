using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoofScript : MonoBehaviour
{
    float woofSpeed = 5f;
    AnimalMovement doggo;
    void Start()
    {
        doggo=GameObject.FindGameObjectWithTag("Player").GetComponent<AnimalMovement>();
    }

    
    void Update()
    {
        transform.position += transform.right*woofSpeed*Time.deltaTime;
        Destroy(gameObject, 0.7f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            doggo.killedEnemies++;
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Yellow Baloon"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Clown"))
        {
            Destroy (gameObject);
        }
    }
}
