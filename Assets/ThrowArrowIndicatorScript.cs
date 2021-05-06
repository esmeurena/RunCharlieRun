using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrowIndicatorScript : MonoBehaviour
{
    public Transform RotatePoint;

    public float rotateSpeed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(RotatePoint.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
