using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPoint : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Player.transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
