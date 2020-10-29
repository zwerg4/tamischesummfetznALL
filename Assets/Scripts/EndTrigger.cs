using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class EndTrigger : MonoBehaviour
{
    public GameObject StartTrigg;
    public GameObject EndTrigg;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    public GameObject WRInput;
    public GameObject WRSubmit;
    public GameObject newWRLabel;

    private int newWRmin;
    private int newWRsec;
    private float newWRmilli;
	
	private int[] newRecmin = new int[10];
    private int[] newRecsec = new int[10];
    private float[] newRecmilli = new float[10];
	private string[] newRecusername = new string[10];
	
	private static int place;

    void OnTriggerEnter()
    {
    	Debug.Log("End Trigger passed with: " + LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + LapTimeManager.MilliCount);
    	EndTrigg.SetActive(false);


		newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\nToo slow, press Restart";
		newWRLabel.SetActive(true);
		
		//WorldRecord loop_wr = new WorldRecord("loop", 00,00,0);
		RecordObject loop_wr = new RecordObject(new [] {"loop","loop","loop","loop","loop","loop","loop","loop","loop","loop"}, new [] {9,9,9,9,9,9,9,9,9,9},new [] {9,9,9,9,9,9,9,9,9,9},new [] {9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f});
		
		
		RestClient.Get<RecordObject>("https://tamischesummerfetzn.firebaseio.com/trackHalloween.json").Then(response =>
		{
			Debug.Log("INSIDE RESTCLIENT, response best: " + response.username[0] + " / " + response.min[0] + " / " + response.sec[0] + " / " + response.milli[0]);
			loop_wr = response;
		});
		
		Debug.Log("loop wrbest: " + loop_wr.username[0] + " / " + loop_wr.min[0] + " / " + loop_wr.sec[0] + " / " + loop_wr.milli[0]);
					
		for(int i = 0; i < 10; i++)
		{
			if(isBetter(Countdown.Rec.min[i],Countdown.Rec.sec[i],Countdown.Rec.milli[i]))
			{
				place = i+1;
				newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\n You are the new " + (i+1) + " !";

				for(int j = 9; j >= i; j--)
				{
					Debug.Log("new rec loop i: "+ i.ToString() + "j: " + j.ToString());
					if(j != i)
					{
						Countdown.Rec.min[j] = Countdown.Rec.min[j-1];	
						Countdown.Rec.sec[j] = Countdown.Rec.sec[j-1];	
						Countdown.Rec.milli[j] = Countdown.Rec.milli[j-1];
						Countdown.Rec.username[j] = Countdown.Rec.username[j-1];
					}
					else
					{
						Countdown.Rec.min[j] = LapTimeManager.MinuteCount;
						Countdown.Rec.sec[j] = LapTimeManager.SecondCount;
						Countdown.Rec.milli[j] = LapTimeManager.MilliCount;
						Countdown.Rec.username[j] = "Database_Write_Error";
					}
				}
				
				newWR();
				break;
			}
			
		}
		
		
		/*
		for(int i = 1; i < 6; i++)
		{
			RestClient.Get<RecordObject>("https://tamischesummerfetzn.firebaseio.com/"+i.ToString()+".json").Then(response =>
			{
				Debug.Log("INSIDE RESTCLIENT, response: " + response.username + " / " + response.min + " / " + response.sec + " / " + response.milli);
				loop_wr = response;
    	    });
			
			if(isBetter(loop_wr.min, loop_wr.sec, loop_wr.milli))
			{
				newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\n You are the new " + i.ToString() + " !";
				place = i;
				newWRmin = LapTimeManager.MinuteCount;
				newWRsec = LapTimeManager.SecondCount;
				newWRmilli = LapTimeManager.MilliCount;
				Debug.Log("New "+ i.ToString() + " vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
				newWR();
				break;
			}
		}*/

      	StartTrigg.SetActive(true);
    	EndTrigg.SetActive(false);
    }


    void newWR()
    {

     	WRInput.SetActive(true);
     	WRSubmit.SetActive(true);
     	newWRLabel.SetActive(true);

		Debug.Log("New WR vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
		
        WorldRecord newWR = new WorldRecord("user", newWRmin, newWRsec, newWRmilli);
		Countdown.WR = newWR;
     	
		//RecordObject newRec = new RecordObject(newRecusername,newRecmin,newRecsec,newRecmilli);
		//Countdown.Rec = newRec;
		
	    Debug.Log("New WR obj: " + newWR.username + "  " + newWR.min +  ":" +  newWR.sec + "." + newWR.milli);
    }


    public void button_pressed()
    {
    	Debug.Log("BUTTON PRESSED, place: " + place + "username: " +  WRInput.GetComponent<Text>().text);

    	//Countdown.WR.username = WRInput.GetComponent<Text>().text;

		Debug.Log("countdown rec: " + Countdown.Rec.username[1]);
		
		//Debug.Log("New WR obj: " + Countdown.WR.username + "  " + Countdown.WR.min +  ":" +  Countdown.WR.sec + "." + Countdown.WR.milli);
       // RestClient.Put("https://tamischesummerfetzn.firebaseio.com/"+place+".json", Countdown.WR);
	   
	   Countdown.Rec.username[place-1] = WRInput.GetComponent<Text>().text;
	   RestClient.Put("https://tamischesummerfetzn.firebaseio.com/trackHalloween.json", Countdown.Rec);

		WRInput.SetActive(false);
     	WRSubmit.SetActive(false);
    }
	
	bool isBetter(int newmin, int newsec, float newmilli)
	{
		
		if(LapTimeManager.MinuteCount < newmin)
    	{
    		//BETTER
			return true;
    	}
    	else if(LapTimeManager.MinuteCount == newmin)
    	{
    	    if(LapTimeManager.SecondCount < newsec)
    	    {
				//BETTER
				return true;
    	    }
    	    else if(LapTimeManager.SecondCount == newsec)
    	    {
    	    	if(LapTimeManager.MilliCount < newmilli)
				{
					//BETTER
					return true;
				}
				else
				{
					return false;
				}
    	    }
    	    else
    	    {
				return false;
    	    }
    	}
    	else
    	{
			return false;
    	}
		
	}
}
