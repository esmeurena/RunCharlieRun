using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToLevel2Collider : MonoBehaviour
{
    private BoxCollider BoxCollider;

    public bool LoadNextLevel = false;

    void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();    
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LoadNextLevel = true;
        }
    }
}
