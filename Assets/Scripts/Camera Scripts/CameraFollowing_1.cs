using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing_1 : MonoBehaviour
{
    public GameObject PlayerFollowPoint;
    public Vector3 CameraOffset;

    public float smoothSpeed = .125f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextPosition = PlayerFollowPoint.transform.position + CameraOffset;
        Vector3 currentPosition = Vector3.Lerp(transform.position, nextPosition, smoothSpeed);
        transform.position = currentPosition;

        transform.LookAt(PlayerFollowPoint.transform.position);
    }
}
