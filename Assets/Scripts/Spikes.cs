using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
    // Update is called once per frame
    void Start()
    {
        iTween.RotateTo(this.gameObject, iTween.Hash("y", 180, "time", 2f, "easetype", easeType, "looptype", loopType));
    }
}
