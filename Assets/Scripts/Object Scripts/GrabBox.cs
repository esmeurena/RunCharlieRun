using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    public bool SensingEquippable = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            SensingEquippable = true;
        }    
        if(other.tag == "Throwable")
        {

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            SensingEquippable = false;
        }
        if(other.tag == "Throwable")
        {

        }
    }
}
