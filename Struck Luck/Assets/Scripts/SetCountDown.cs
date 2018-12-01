using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour {

    private GameController GC;
    public void SetCountDownNow()
    {
        GC = GameObject.Find("Player").GetComponent<GameController>();
        GC.countDownDone = true;
    }

}
