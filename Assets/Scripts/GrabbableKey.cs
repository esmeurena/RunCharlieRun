using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableKey : MonoBehaviour
{
    private CharlieController1 CCS;
    private Rigidbody rb;
    private MeshCollider Collider;

    public bool Equipped = false;

    private GameObject ItemHoldingPoint;
    private Vector3 StartPos;

    float startTime;
    float TimeItTakes = 0.3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Collider = GetComponent<MeshCollider>();
        ItemHoldingPoint = GameObject.Find("Item Holding Point");
        CCS = GameObject.Find("Charlie Player 1").GetComponent<CharlieController1>();
    }

    void FixedUpdate()
    {
        if (!CCS.Equipped)
        {
            rb.useGravity = true;

            if (CCS.ItemIsLerping)
            {
                Collider.isTrigger = true;

                if (CCS.StartItemLerp)
                {
                    startTime = Time.time;
                    StartPos = transform.position;
                    CCS.StartItemLerp = false;
                }

                Vector3 Distance = ItemHoldingPoint.transform.position - transform.position;
                float TimeSinceStart = Time.time - startTime;
                float percentage = TimeSinceStart / TimeItTakes;
                transform.position = Vector3.Lerp(StartPos, ItemHoldingPoint.transform.position, percentage);
                if (Distance.magnitude < 0.2f)
                {
                    CCS.Equipped = true;
                    CCS.ItemIsLerping = false;
                }
            }

        }
        if (CCS.Equipped)
        {
            Collider.isTrigger = false;
            rb.useGravity = false;
            transform.position = ItemHoldingPoint.transform.position;
        }
    }
}
