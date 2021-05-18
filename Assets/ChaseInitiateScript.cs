using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseInitiateScript : MonoBehaviour
{
    public ChaseScript CS;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CS.PlayerFound = true;
        }    
    }
}
