using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Update is called once per frame
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public GameObject thePlayer;
    Vector3 velocity;
    private void OnTriggerEnter(Collider other)
    {
        //thePlayer.transform.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
