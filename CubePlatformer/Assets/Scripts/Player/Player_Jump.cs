using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] float jumpForce = 11f;
    [SerializeField] float jumpRadius = 0.34f;
    [SerializeField] LayerMask layerGround;
    [SerializeField] Transform groundCheck;

    Rigidbody myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        SetJumpHeight();
    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (Physics.OverlapSphere(groundCheck.position, jumpRadius, layerGround).Length > 0)
            {
                myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
            }
        }
    }

    void SetJumpHeight()
    {
        if (Input.GetButtonUp("Jump") && myRb.velocity.y > 0) //Entre mas tiempo presionas la tecla, mas alto saltara.
        {
            myRb.velocity = new Vector2(myRb.velocity.x, myRb.velocity.y * 0.5f);
        }
    }

}
