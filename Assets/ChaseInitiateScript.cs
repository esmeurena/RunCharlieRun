using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseInitiateScript : MonoBehaviour
{
    public ChaseScript CS;
    public ChaseVariantScript CVS;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(CS != null)
                CS.PlayerFound = true;
            if (CVS != null)
                CVS.PlayerFound = true;
        }    
    }
}
