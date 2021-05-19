using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTheLightsColliderScript : MonoBehaviour
{
    public Light L1;
    public Light L2;

    void Start()
    {
        L1.enabled = false;
        L2.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            L1.enabled = true;
            L2.enabled = true;
        }    
    }

}
