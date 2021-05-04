using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieController : MonoBehaviour
{
    Rigidbody rb;
    public GroundChecker GCS;
    public LedgeRaycast LRS;
    //public BoxCollider GroundCheck;

    public float moveSpeed;
    public float jumpForce;

    float horizontal;
    //   float vertical;

    private Vector3 rightLookAngle = new Vector3(0f, 0f, 0f);
    private Vector3 leftLookAngle = new Vector3(0f, 180f, 0f);

    bool jump;

    float yVelocity = 0f;
    float smooth = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (LRS.Grappling && GCS.Grounded == false)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;

            if (Input.GetKeyDown("s"))
            {
                LRS.Grappling = false;
                StartCoroutine(DisableGrapple());
                rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && GCS.Grounded)
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && LRS.Grappling && GCS.Grounded == false)
        {
            jump = true;

            LRS.Grappling = false;
            StartCoroutine(DisableGrapple());
            rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y, rb.velocity.z);

        if (LRS.Grappling == false)
        {
            if (horizontal > 0 && transform.eulerAngles != new Vector3(0f, 0f, 0f))
            {
                //Quaternion.Euler(0f, 0f, 0f);
                //transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(rightLookAngle.y, leftLookAngle.y, Time.deltaTime), 0f);
                float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 0f, ref yVelocity, smooth);
                transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
            }

            if (horizontal < 0 && transform.eulerAngles != new Vector3(0f, 180f, 0f))
            {
                //transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(leftLookAngle.y, rightLookAngle.y, Time.deltaTime), 0f);
                float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 180f, ref yVelocity, smooth);
                transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
            }
        }

        if (jump)
        {
            rb.AddForce(new Vector3(0f, jumpForce * Time.deltaTime, 0f),ForceMode.Impulse);
            jump = false;
        }
    }

    IEnumerator DisableGrapple()
    {
        LRS.DisableGrapple = true;
        yield return new WaitForSeconds(.5f);
        LRS.DisableGrapple = false;
    }
}
