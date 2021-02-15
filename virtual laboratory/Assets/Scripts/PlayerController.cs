using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
   
    public CharacterController characterController;
    public float speed = 3;

    public Animator animator;

    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;
    private float verticalSpeed = 0;
    private float gravity = 9.87f;
    private Vector3 movementDirection = Vector3.zero;

    //jumping
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;
        
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        MoveV();
        Rotate();

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool("isJumping", !characterController.isGrounded);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

       

    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Vertical");
        float verticalMove = Input.GetAxis("Horizontal");

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * verticalMove + (-1)*transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        animator.SetBool("isWalking", verticalMove != 0 || horizontalMove != 0);
    }

    private void MoveV()
    {
        float verticalMove = Input.GetAxis("Vertical");
        

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = (-1) * transform.right * verticalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        animator.SetBool("isWalking", verticalMove != 0);
    }

}