using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutsceneFollowerScript : MonoBehaviour
{
    public GameObject Player;
    public CameraFollowing CFS;
    public GameObject CutsceneTarget;
    float timeElapsed = 0;

    void FixedUpdate()
    {

        if (CFS.NewTarget)
        {
            transform.position = Vector3.Lerp(Player.transform.position, CutsceneTarget.transform.position, timeElapsed);
            if (timeElapsed < 1f)
                timeElapsed = timeElapsed + Time.deltaTime * .05f;
        }
        else
        {
            transform.position = Player.transform.position;
        }

    }
}
