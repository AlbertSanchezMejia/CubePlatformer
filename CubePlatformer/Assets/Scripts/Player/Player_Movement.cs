using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody myRb;
    [SerializeField] float gravityScale = 1f;

    [Header ("Movement")]
    [SerializeField] float speed = 30f;
    float horizontalDirection;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        float horizontalMovement = horizontalDirection * speed;
        //float VerticalMovement = -gravityScale ;

        Vector3 movementDirection = (transform.right * horizontalMovement) + (transform.up * -gravityScale);

        myRb.velocity = movementDirection * Time.fixedDeltaTime * 10;
    }


}
