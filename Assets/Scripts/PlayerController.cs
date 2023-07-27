using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float gravityScale;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce;

    private Vector3 lookVector;
    private Vector3 targetVector;
    private Vector3 gravityVector;

    private Animator animator;


    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        gravityVector = Vector3.zero;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


       

       
        gravityVector.y -= gravityScale * Time.deltaTime;
           
        if(IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravityVector.y = Mathf.Sqrt(jumpForce * 2 * gravityScale);
                animator.SetTrigger("Jump");
            }

        }


        Vector3 moveVector =
            new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z) * x +
            new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z) * z;

        controller.Move(moveVector * moveSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
        

        targetVector = transform.position + moveVector;

        lookVector = Vector3.Lerp(transform.position + transform.forward, targetVector, Time.deltaTime * rotateSpeed);


        transform.LookAt(lookVector);

        if (moveVector != Vector3.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        
    }

    private bool IsGrounded()
    {
        return Physics.OverlapSphere(groundCheck.position, groundCheckRadius).Length > 1;
    }
}
