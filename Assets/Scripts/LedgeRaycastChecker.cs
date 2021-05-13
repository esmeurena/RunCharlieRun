using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeRaycastChecker : MonoBehaviour
{
    public LedgeRaycast LRS;

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.up, .5f))
        {
            LRS.OutsideDisable = true;
        }
        else
        {
            LRS.OutsideDisable = false;
        }
    }
}
