using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    //This is script for any third person controlled game that you want
    //It is incredibly adapatable and you can change a lot of things to fit the game that you want to make
    //Make sure to use this with the character contoller and not the rigidbody system
    //This does not take into account camera movement as the camera is being controlled by cinemachine
    //THANK YOU BRACKEYS

    public CharacterController CC; 
    public Transform Camera;
    public Transform GravSphere;

    private Vector3 yVelocity;

    float horizontal;
    float vertical;

    public float speed = 1f;

    public float Smooth = 0.1f;
    float turnVel;

    public float gravityForce = -9.81f;

    public float jumpForce = 5;

    public bool Grounded;
    public float DistToGrd = 1.2f;

    bool Ray1;
    bool Ray2;
    bool Ray3;
    bool Ray4;
    bool Ray5;

    int InAirJump = 1;
    public float jumpSoftener;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Grounded)
        {
            InAirJump = 1;
        }

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            yVelocity.y = jumpForce * Time.deltaTime;
            CC.Move(yVelocity * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && !Grounded && InAirJump == 1)
        {
            yVelocity.y = 0;
            InAirJump--;
            yVelocity.y = jumpForce * jumpSoftener * Time.deltaTime;
            CC.Move(yVelocity * Time.deltaTime);
        }

        if (direction.magnitude >= 0.1f)
        {
            float BigAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float LittleAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, BigAngle, ref turnVel, Smooth);
            transform.rotation = Quaternion.Euler(0f, LittleAngle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, BigAngle, 0f) * Vector3.forward;
            if (Grounded)
            {
                CC.Move(MoveDir.normalized * speed * Time.deltaTime);
            }
            else
            {
                CC.Move(MoveDir.normalized * speed * Time.deltaTime * 0.8f);
            }
        }

        CheckAndApplyGravity();
    }

    void CheckAndApplyGravity()
    {
        RaycastHit HitInfo1;
        if (Physics.Raycast(transform.position, transform.up * -1, out HitInfo1))
        {
            float HitDistance1 = HitInfo1.distance;
            if (HitDistance1 <= DistToGrd)
            {
                Ray1 = true;
            }
            else
            {
                Ray1 = false;
            }
        }

        RaycastHit HitInfo2;
        if (Physics.Raycast(transform.position + new Vector3(0f, 0f, .5f), transform.up * -1, out HitInfo2))
        {
            float HitDistance2 = HitInfo2.distance;
            if (HitDistance2 <= DistToGrd)
            {
                Ray2 = true;
            }
            else
            {
                Ray2 = false;
            }
        }

        RaycastHit HitInfo3;
        if (Physics.Raycast(transform.position + new Vector3(0f, 0f, -.5f), transform.up * -1, out HitInfo3))
        {
            float HitDistance3 = HitInfo3.distance;
            if (HitDistance3 <= DistToGrd)
            {
                Ray3 = true;
            }
            else
            {
                Ray3 = false;
            }
        }

        RaycastHit HitInfo4;
        if (Physics.Raycast(transform.position + new Vector3(-.5f, 0f, 0f), transform.up * -1, out HitInfo4))
        {
            float HitDistance4 = HitInfo4.distance;
            if (HitDistance4 <= DistToGrd)
            {
                Ray4 = true;
            }
            else
            {
                Ray4 = false;
            }
        }

        RaycastHit HitInfo5;
        if (Physics.Raycast(transform.position + new Vector3(.5f, 0f, 0f), transform.up * -1, out HitInfo5))
        {
            float HitDistance5 = HitInfo5.distance;
            if (HitDistance5 <= DistToGrd)
            {
                Ray5 = true;
            }
            else
            {
                Ray5 = false;
            }
        }

        if (Ray1 || Ray2 || Ray3 || Ray4 || Ray5)
        {
            Grounded = true;
            gravityForce = 0;
            yVelocity.y = 0;
        }
        else
        {
            Grounded = false;
            gravityForce = -9.81f;
        }
        
        yVelocity.y += gravityForce * Time.deltaTime;
        CC.Move(yVelocity * Time.deltaTime);
    }

}
