using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGhostColliderScipt : MonoBehaviour
{
    public GameObject Ghosts;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(Ghosts);
        }    
    }
}
