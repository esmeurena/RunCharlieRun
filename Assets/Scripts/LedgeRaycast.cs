using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeRaycast : MonoBehaviour
{
    public bool Grappling = false;
    public bool DisableGrapple = false;
    public bool OutsideDisable = false;

    public GameObject Player;
    public LayerMask Ignored;
    private float hitPointY;
    //private float hitPointX;

    // Update is called once per frame
    void Update() 
    {
        if (!OutsideDisable)
        {
            if (!DisableGrapple)
            {
                RaycastHit hitPoint;
                if (Physics.Raycast(transform.position, transform.right, out hitPoint, 1f, ~Ignored))
                {
                    if (hitPoint.normal.y > .9f)
                    {
                        Grappling = true;
                        hitPointY = hitPoint.point.y;
                        //hitPointX = hitPoint.point.x;
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

    void FixedUpdate()
    {
        if (Grappling)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, hitPointY - 1f, Player.transform.position.z);
        }    
    }
}
