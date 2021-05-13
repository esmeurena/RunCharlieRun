using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFallColliderScript : MonoBehaviour
{
    public CharlieController1 CC1S;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has entered the ending box");
            CC1S.DisabledMovement = false;
        }    
    }
}
