using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool isLadder, isSkyLift;
    public float ladderHeight = 3.2f;
    public CharacterController playerInput;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<CharacterController>();
        isLadder = false;
        isSkyLift = false;
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            playerInput.minMoveDistance = 2000f;
            isLadder = !isLadder;
        }
        else if (other.gameObject.CompareTag("SkyLift"))
        {
            playerInput.minMoveDistance = 2000f;
            isSkyLift = !isSkyLift;
        }
    }

  private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            playerInput.minMoveDistance = 0.001f;
            isLadder = !isLadder;
        }
        else if (other.gameObject.CompareTag("SkyLift"))
        {
            playerInput.minMoveDistance = 0.001f;
            isSkyLift = !isSkyLift;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isLadder && Input.GetKey("w"))
        {
            playerController.transform.position += Vector3.up / ladderHeight;
        }
        else if (isLadder && Input.GetKey("s"))
        {
            if (!isGrounded)
            {
                playerController.transform.position += Vector3.down / ladderHeight;
            }
            else
            {
                playerInput.minMoveDistance = 0.001f;
            }
        }
        
        if (isSkyLift)
        {
            playerController.transform.position += Vector3.forward / ladderHeight;
        }
    }
}
