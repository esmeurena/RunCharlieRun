using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRelease : MonoBehaviour
{
    private LedgeRaycast LRS;
    public FallingWood FWS;

    // Start is called before the first frame update
    void Start()
    {
        LRS = GameObject.Find("Ledge Raycast").GetComponent<LedgeRaycast>();
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if (LRS.Grappling == true)
            {
                FWS.TriggerFall();
            }
        }    
    }
}
