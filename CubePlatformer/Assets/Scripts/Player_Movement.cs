using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody myRb;

    [Header ("Movement")]
    [SerializeField] float speed = 30f;
    float horizontalMovement;

    [Header("Jump")]
    [SerializeField] float jumpForce = 11f;
    [SerializeField] float jumpRadius = 0.34f;
    [SerializeField] LayerMask layerGround;
    [SerializeField] Transform groundCheck;

    [Header("Teleporting")]
    [SerializeField] Rigidbody otherRb;

    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        myRb.velocity = otherRb.velocity;
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        Jump();
        SetJumpHeight();
    }

    void FixedUpdate()
    {
        float xMovement = horizontalMovement * speed * Time.fixedDeltaTime * 10;
        myRb.velocity = new Vector2(xMovement, myRb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if(Physics2D.OverlapCircle(groundCheck.position, jumpRadius, layerGround))
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
