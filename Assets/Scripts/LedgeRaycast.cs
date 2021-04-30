using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeRaycast : MonoBehaviour
{
    public bool Grappling = false;
    public bool DisableGrapple = false;

    // Update is called once per frame
    void Update() 
    {
        if (!DisableGrapple)
        {
            RaycastHit hitPoint;
            if (Physics.Raycast(transform.position, transform.right, out hitPoint, 1f))
            {
                if (hitPoint.normal.y > .9f)
                {
                    Grappling = true;
                    Debug.Log("we are sensing the ledge");
                }
                else
                {
                    Grappling = false;
                }
            }
            else
            {
                Grappling = false;
            }
        }
    }
}
