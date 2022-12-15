using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBaloonParot : MonoBehaviour
{
    public Transform outofBounds;
    public GameObject weapon;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        weapon.SetActive(false);
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, outofBounds.position, 10f*Time.deltaTime);
    }
}

