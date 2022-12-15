using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStageScript : MonoBehaviour
{
    public Transform door;
    float clownSpeed = 1;
    float step;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 3, true);
        Physics2D.IgnoreLayerCollision(7, 9, true);
    }

    void FixedUpdate()
    {
    
        transform.position = Vector2.MoveTowards(transform.position, door.position, clownSpeed*Time.deltaTime);
    }
}
