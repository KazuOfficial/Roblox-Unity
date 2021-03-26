using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool isLadder;
    public float ladderHeight = 3.3f;
    public CharacterController playerInput;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<CharacterController>();
        isLadder = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            playerInput.enabled = false;
            isLadder = !isLadder;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            playerInput.enabled = true;
            isLadder = !isLadder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLadder && Input.GetKey("w"))
        {
            while (playerController.transform.position.y < playerController.transform.position.y + ladderHeight)
            {
                playerController.transform.position += Vector3.up / ladderHeight;
            }
        }
    }
}
