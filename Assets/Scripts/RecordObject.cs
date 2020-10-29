using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RecordObject
{
    public int[] min = new int[10];
    public int[] sec = new int[10];
    public float[] milli = new float[10];
    public string[] username = new string[10];
    
    public RecordObject(string[] username_, int[] min_, int[] sec_, float[] milli_)
    {
    	Debug.Log("Record constructor");
    	username = username_;
    	min = min_;
    	sec = sec_;
    	milli = milli_;
    }
}
