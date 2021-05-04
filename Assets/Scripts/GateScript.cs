using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    private bool open = false;
    private Rigidbody rb;
    private HingeJoint hj;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Key")
        {
            //open = true;
            rb.constraints = RigidbodyConstraints.None;// | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("Door is open");
        }   
    }
}
