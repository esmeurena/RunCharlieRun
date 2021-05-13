using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieController1 : MonoBehaviour
{ 
    Rigidbody rb;
    public GroundChecker GCS;
    public LedgeRaycast LRS;
    public GrabBox GBS;
    private Rigidbody GTOS;
    public CutsceneToLevel2Collider CTL2CS;

    public float moveSpeed;
    public float jumpForce;
    public float throwForce;

    float horizontal;

    bool jump;

    float yVelocity = 0f;
    float smooth = 0.2f;

    public bool Equipped = false;
    public bool ItemIsThrowable = false;
    public bool ThrowItem = false;
    public bool ItemIsLerping = false;
    public bool StartItemLerp = false;
    public bool DisabledMovement = false;

    bool Paused = false;
    bool Called = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // GBS = GameObject.Find("Grab Box").GetComponent<GrabBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DisabledMovement)
        {
            if (!CTL2CS.LoadNextLevel)
            {
                horizontal = Input.GetAxisRaw("Horizontal");

                if (LRS.Grappling && GCS.Grounded == false)
                {
                    rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

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
                if (Input.GetKeyDown(KeyCode.Space) && LRS.Grappling) //&& GCS.Grounded == false)
                {
                    jump = true;

                    LRS.Grappling = false;
                    StartCoroutine(DisableGrapple());
                    rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
                }
                if (Equipped == true && ItemIsThrowable == true)
                {
                    GTOS = GBS.Throwable.GetComponent<Rigidbody>();
                }
                if (Input.GetKeyDown("e") && GBS.SensingEquippable == true && ItemIsLerping == false && Equipped == false)
                {
                    ItemIsLerping = true;
                    StartItemLerp = true;
                }
                if (Input.GetMouseButtonDown(0) && Equipped == true && ItemIsThrowable == true)
                {
                    ItemIsThrowable = false;
                    Equipped = false;
                    ThrowItem = true;
                }
                if (Input.GetKeyDown("e") && Equipped == true)
                {
                    Equipped = false;
                    if (ItemIsThrowable)
                    {
                        GTOS.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
                        GTOS = null;
                        Debug.Log(GTOS);
                    }
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, -9.81f, 0f);
        }
        
    }

    void FixedUpdate()
    {
        if (ThrowItem)
        {
            GTOS.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
            GTOS.AddForce((transform.right * throwForce + transform.up * throwForce) * Time.deltaTime, ForceMode.Impulse);
            GTOS = null;
            ThrowItem = false;
        }
        if (LRS.Grappling == false)
        {
            rb.velocity = new Vector3(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y, 0f);
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           
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
            rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);
            rb.AddForce(new Vector3(0f, jumpForce * Time.deltaTime, 0f),ForceMode.Impulse);
            jump = false;
        }

        if (CTL2CS.LoadNextLevel)
        {
            if (!Paused)
            {
                rb.velocity = new Vector3(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y, 0f);
                if (!Called)
                {
                    StartCoroutine("PausePlayer");
                    Called = true;
                }
                    
            }
        }
    }

    IEnumerator DisableGrapple()
    {
        LRS.DisableGrapple = true;
        yield return new WaitForSeconds(.2f);
        LRS.DisableGrapple = false;
    }

    IEnumerator PausePlayer()
    {
        yield return new WaitForSeconds(8f);
        Paused = true;
    }
}
