using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingDoor : MonoBehaviour
{
    public bool Rising = false;

    void FixedUpdate()
    {
        if (Rising)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .05f, transform.position.z);
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        Rising = true;     
    }
}
