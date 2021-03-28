using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static List<Keys> inv = new List<Keys>();
    public GameObject one, two, three;
    // Update is called once per frame

    public static void AddKey(Keys key)
    {
        if (inv.Count < 10 && !inv.Contains(key))
        {
            inv.Add(key);
        }
    }
    void Update()
    {
        foreach (var keylevel in inv)
        {
            //one.GetComponent<Image>().sprite = keysprite;
            Debug.Log(keylevel);
        }
    }
}
