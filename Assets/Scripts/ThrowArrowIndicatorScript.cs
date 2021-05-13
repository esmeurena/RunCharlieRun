using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrowIndicatorScript : MonoBehaviour
{
    public Transform RotatePoint;
    private SpriteRenderer sprite;

    public float rotateSpeed = 20f;
    float StartMousePos;

    bool MouseThings = false;
    bool GetMouseStartPos = true;
   

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            MouseThings = true;
            Debug.Log(Input.mousePosition);

            if(GetMouseStartPos)
                StartMousePos = Input.mousePosition.y;

            GetMouseStartPos = false;
        }
        else
        {
            MouseThings = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MouseThings)
        {
            sprite.enabled = true;
            if (Input.mousePosition.y < StartMousePos)
                rotateSpeed = -20f;
            if (Input.mousePosition.y > StartMousePos)
                rotateSpeed = 20f;

            transform.RotateAround(RotatePoint.position, RotatePoint.transform.forward, rotateSpeed * Time.deltaTime);
        }
        else
        {
            sprite.enabled = false;
            GetMouseStartPos = true;
        }
    }
}
