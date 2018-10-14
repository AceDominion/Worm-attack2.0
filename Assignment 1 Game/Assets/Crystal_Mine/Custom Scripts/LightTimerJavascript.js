#pragma strict

var lightToDim : Light;    
var maxTime : float = 1; //30 seconds

var mEndTime : float = 0;
var mStartTime : float = 0;
 
function Awake()
{
    mStartTime = Time.time;
    mEndTime = mStartTime + maxTime;
}

 
function Update()
{
    if(lightToDim)
         lightToDim.intensity = Mathf.InverseLerp(mStartTime, mEndTime, Time.time);
        //lightToDim.intensity = 20;
}


