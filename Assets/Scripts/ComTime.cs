using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComTime : MonoBehaviour
{
    public Text textTimer;
    public float timeNow = 0;
    int min;
    float sec;
    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        timeNow += Time.deltaTime;

        min = (int)timeNow/ 60;
        sec = (int)timeNow % 60;
        if (min < 10)
        {
            if (sec < 10)
            {
                textTimer.text = "0" + min + ":0" + sec;
            }
            else
            {
                textTimer.text = "0" + min + ":" + sec;
            }
        }
        else
        {
            if (sec < 10)
            {
                textTimer.text = min + ":0" + sec;
            }
            else
            {
                textTimer.text = min + ":" + sec;
            }
        }
    }
}
