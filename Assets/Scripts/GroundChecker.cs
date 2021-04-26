using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool Grounded = false;
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag != "Player")
        {
            Grounded = true;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Player")
        {
            Grounded = false;
        }    
    }
}
