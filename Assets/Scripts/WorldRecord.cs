using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WorldRecord
{
    public int min;
    public int sec;
    public float milli;
    public string username;
    
    public WorldRecord(string username_, int min_, int sec_, float milli_)
    {
    	Debug.Log("New WR constructor: " + min_ +  ":" +  sec_ + "." + milli_);
    	username = username_;
    	min = min_;
    	sec = sec_;
    	milli = milli_;
    }
}
