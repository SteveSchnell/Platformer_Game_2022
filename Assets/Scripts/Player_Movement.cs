using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    CharacterController controller;

    public float turnSmoothing = 15f,
        jumpSpeed,
        movement;

    private float verticalVelocity,
        h,
        v;

    private Vector3 offset;

    private bool doubelJump = true;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        offset.x = Input.GetAxisRaw("Horizontal");
        offset.y = Input.GetAxisRaw("Vertical");

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            verticalVelocity = 0;
            doubelJump = true;
        }

        if ((controller.isGrounded || doubelJump) && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;

            if (!controller.isGrounded)
                doubelJump = false;
        }       

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        Vector3 speed = new Vector3(0, verticalVelocity, offset.magnitude * movement);
        speed = transform.rotation * speed;
        controller.Move(speed * Time.deltaTime);

        if (h != 0f || v != 0f)
        {
            Rotating(h, v);
        }

    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        transform.rotation = newRotation;
    }
}
