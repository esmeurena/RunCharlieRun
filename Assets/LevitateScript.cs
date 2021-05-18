using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateScript : MonoBehaviour
{
    public GameObject FloatPoint;
    public float FloatOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(0f, Mathf.Sin(Time.time - FloatOffset) *.5f, 0f) + FloatPoint.transform.position;
    }
}
