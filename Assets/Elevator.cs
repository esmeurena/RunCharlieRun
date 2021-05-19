using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public CharlieController1 CC1S;
    public GameObject finalPosition;

    bool Elevate = false;
    float TimeElapsed = 0f;
    public float SmoothRate;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable" && CC1S.Equipped == true)
        {
            Elevate = true;
        }
    }

    void FixedUpdate()
    {
        if (Elevate)
        {
            transform.position = Vector3.Lerp(transform.position, finalPosition.transform.position, TimeElapsed);
            if(TimeElapsed < 1f)
            {
                TimeElapsed = TimeElapsed + Time.deltaTime * SmoothRate;
            }
        }    
    }
}
