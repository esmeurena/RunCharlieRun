using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    public bool SensingEquippable = false;
    public GameObject Throwable;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            SensingEquippable = true;
        }    
        if(other.tag == "Throwable")
        {
            SensingEquippable = true;
            Throwable = other.gameObject;
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
            SensingEquippable = false;
            Throwable = null;
        }
    }
}
