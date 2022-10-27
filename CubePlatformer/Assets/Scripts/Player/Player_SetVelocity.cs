using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SetVelocity : MonoBehaviour
{
    [Header("Teleporting")]
    [SerializeField] Rigidbody otherRb;
    Rigidbody myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (otherRb != null) { myRb.velocity = otherRb.velocity; }
    }

}
