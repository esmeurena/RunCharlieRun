using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameMasterScript GMS;
    public GameObject Ghosts;

    void Start()
    {
        GMS = GameObject.Find("Game Master").GetComponent<GameMasterScript>();    
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GMS.LastPosition = transform.position;
            Destroy(Ghosts);
        }    
    }
}
