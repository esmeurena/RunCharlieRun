using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWood : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void TriggerFall()
    {
        rb.useGravity = true;
    }
}
