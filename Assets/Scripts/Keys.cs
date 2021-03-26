using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    //public bool yellowkey = false;
    void OnTriggerEnter(Collider other)
    {
        door.GetComponent<Collider>().enabled = false;
        var col = door.GetComponent<Renderer>().material.color;
        col.a = 0.5f;
    }
}
