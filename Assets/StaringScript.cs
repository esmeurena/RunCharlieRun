using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaringScript : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player.transform.position);
    }
}
