using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{ 
    public GameObject PlayerFollowPoint;
    public Vector3 CameraOffset;
    public CutsceneToLevel2Collider CTL2CS;
    public GameObject CutsceneTarget;

    bool CutsceneCalled = false;
    public bool NewTarget = false;

    public float smoothSpeed = .125f;

    // Update is called once per frame
    void Update()
    {
        if (CTL2CS.LoadNextLevel)
        {
            smoothSpeed = 0.005f;
            CameraOffset = new Vector3(10f, 5f, -20f);
            if (!CutsceneCalled)
            {
                StartCoroutine("LoadNextScene");
                CutsceneCalled = true;
            }
        }    
    }

    void FixedUpdate()
    {
        if (!NewTarget)
        {
            Vector3 nextPosition = PlayerFollowPoint.transform.position + CameraOffset;
            Vector3 currentPosition = Vector3.Lerp(transform.position, nextPosition, smoothSpeed);
            transform.position = currentPosition;

            transform.LookAt(PlayerFollowPoint.transform.position);
        }
        else
        {
            Vector3 nextPosition = CutsceneTarget.transform.position + CameraOffset;
            Vector3 currentPosition = Vector3.Lerp(transform.position, nextPosition, smoothSpeed);
            transform.position = currentPosition;

            transform.LookAt(CutsceneTarget.transform.position);
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        NewTarget = true;
        yield return new WaitForSeconds(8f);
        Application.LoadLevel("MenuScene");
    }
}
