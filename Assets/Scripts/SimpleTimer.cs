using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    public bool timeReady;
    public float timeCD = 1.2f;
    public float timeCurrent = 0.0f;

    public void Update()
    {
        if (timeCurrent >= timeCD)
        {
            timeReady = true;
        }
        else
        {
            timeCurrent += Time.deltaTime;
            timeReady = false;
            timeCurrent = Mathf.Clamp(timeCurrent, 0.0f, timeCD);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& timeReady)
        {
            timeCurrent = 0.0f;
        }
    }
}
