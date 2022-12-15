using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScri : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
        Destroy (gameObject);
        }
    }
    void cutDestroy()
    {
        Destroy(gameObject);
    }
}
