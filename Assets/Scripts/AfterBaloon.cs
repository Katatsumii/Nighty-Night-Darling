using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBaloon : MonoBehaviour
{
    AnimalMovement3 animal;
    public Transform outofBounds;
        private void Start()
    {
        animal = GetComponent<AnimalMovement3>();
        Physics2D.IgnoreLayerCollision(12,8,true);
    }
    void FixedUpdate()
    {
        if(animal.isFacingRight==false)
        {
            animal.Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, outofBounds.position, 5f*Time.deltaTime);
    }
}
