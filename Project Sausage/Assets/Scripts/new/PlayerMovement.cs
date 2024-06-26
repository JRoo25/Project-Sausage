using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public Animator animator;

    [HideInInspector] public TextMeshProUGUI text_speed;

    public Camera playerCamera;

    AudioManager audioManager;

    // Ladder climbing variables
    private bool onLadder = false;
    public float climbSpeed = 3f;

    public bool isClimbing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.3f + 0.15f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded && !onLadder)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (onLadder)
        {
            ClimbLadder();
        }

        animator.SetBool("isWalking", Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0 && !onLadder);
        animator.SetBool("isClimbing", isClimbing);
    }

    public void DisableMovement()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (!onLadder)
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Existing jump condition
        if (Input.GetKey(jumpKey) && readyToJump && grounded && !onLadder)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        Vector3 camForward = playerCamera.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 moveDirection = camForward * verticalInput + playerCamera.transform.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void ClimbLadder()
    {
        Vector3 climbDirection = new Vector3(0f, verticalInput, 0f);

        rb.velocity = climbDirection * climbSpeed;

        isClimbing = true;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed && !onLadder)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        audioManager.PlaySFX(audioManager.jump);

        Invoke(nameof(ResetJumpParam), jumpCooldown);
    }

    private void ResetJumpParam()
    {
        animator.SetBool("isJumping", false);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = true;
            rb.useGravity = false;
        }

        if (other.CompareTag("Finish"))
        {
            audioManager.PlaySFX(audioManager.finish);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = false;
            rb.useGravity = true;

            isClimbing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            DisableMovement();
            audioManager.StopBackgroundMusic();
        }
    }
}


