using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightTimer : MonoBehaviour
{
    public Light lightToDim = null;
    public float maxTime = 1; //30 seconds
    public float mEndTime = 0;
    public float mStartTime = 0;


    void Awake()
    {
        mStartTime = Time.time;
        mEndTime = mStartTime + maxTime;
         //mEndTime = Time.time;
         //mStartTime = mEndTime + maxTime;
    }



    void Update()
    {
        if (lightToDim)
            lightToDim.intensity = Mathf.InverseLerp(mEndTime, mStartTime, Time.time);
    }

}