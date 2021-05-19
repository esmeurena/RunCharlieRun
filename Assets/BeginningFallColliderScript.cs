using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningFallColliderScript : MonoBehaviour
{
    public CameraFollowing Camera;
    public CharlieController1 CC1S;
    public LedgeRaycast LRS;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CC1S.DisabledMovement = true;
            StartCoroutine("DisableLedgeRaycast");
        }
            
    }

    IEnumerator DisableLedgeRaycast()
    {
        LRS.enabled = false;
        yield return new WaitForSeconds(2f);
        LRS.enabled = true;
    }
} 
