using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFallColliderScript : MonoBehaviour
{
    public CharlieController1 CC1S;
    public LedgeRaycast LRS;
    public GameObject BackgroundEnemies;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has entered the ending box");
            CC1S.DisabledMovement = false;
            StartCoroutine("DisableLedgeRaycast");
            StartCoroutine("DestroyBackgroundEnemies");
        }    
    }

    IEnumerator DisableLedgeRaycast()
    {
        LRS.enabled = false;
        yield return new WaitForSeconds(2f);
        LRS.enabled = true;
    }

    IEnumerator DestroyBackgroundEnemies()
    {
        yield return new WaitForSeconds(3f);
        Destroy(BackgroundEnemies);
    }
}
