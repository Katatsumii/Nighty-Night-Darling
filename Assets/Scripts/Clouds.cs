using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position +=new Vector3 (speed*Time.deltaTime, transform.position.y,transform.position.z);

        if (transform.position.x<-15)
        {
            
            transform.position= new Vector3 (22,transform.position.y,transform.position.z);   
        }
    }
}
