using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public GameObject Player;
    public float ChaseSpeed;
    public bool PlayerFound = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerFound)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, ChaseSpeed);
        }
    }
}
