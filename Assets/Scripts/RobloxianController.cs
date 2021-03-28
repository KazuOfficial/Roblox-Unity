using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobloxianController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public Animator animator;

    public float gravity = -9.81f;

    public float speed = 6f;
    public float jumpspeed = 5;
    public float turnSmoothTime = 0.1f;

    public float groundDistance = 0.4f;

    Vector3 velocity;

    public LayerMask groundMask;

    bool isGrounded;
    bool isMoving;
    public float jumpHeight = 3f;

    float turnSmoothVelocity;

    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            isMoving = true;
        }

        if (direction.magnitude <= 0.0f)
        {
            isMoving = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * Time.deltaTime);
        }

        if (isGrounded != true)
        {
            animator.SetBool("Robloxian In Air", true);
        }
        else
        {
            animator.SetBool("Robloxian In Air", false);
        }

        if (isMoving)
        {
            animator.SetBool("Robloxian In Move", true);
        }
        else if (isMoving == false)
        {
            animator.SetBool("Robloxian In Move", false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpPad"))
        {
            velocity.y = Mathf.Sqrt(8f * -2f * gravity);
        }
        else if (other.gameObject.CompareTag("JumpPadToSky"))
        {
            velocity.y = Mathf.Sqrt(40f * -2f * gravity);
        }
        else if (other.gameObject.CompareTag("JumpPadMush"))
        {
            velocity.y = Mathf.Sqrt(52f * -2f * gravity);
        }
    }
}
