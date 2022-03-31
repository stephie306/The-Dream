using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float x;
    private float z;
    private Vector3 moveDirection = Vector3.zero;

    public float speed = 5.0f;
    public float jump = 3f;
    public float shiftSpeed = 10.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    Rigidbody character;

    void Start()
    {
        character = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded)
        {
            moveDirection = new Vector3(x, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection = speed * moveDirection;

        }

        GetComponent<Rigidbody>().MovePosition(transform.position + moveDirection * Time.deltaTime);
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Impulse);
        }
    }
}
