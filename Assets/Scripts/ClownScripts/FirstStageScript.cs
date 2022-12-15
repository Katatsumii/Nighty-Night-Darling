using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageScript : MonoBehaviour
{
    public Transform door;
    float clownSpeed = 1;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 3, true);
        Physics2D.IgnoreLayerCollision(7,8,false);
        Physics2D.IgnoreLayerCollision(7,12,true);
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, door.position, clownSpeed*Time.deltaTime);
    }
}
