using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class Countdown : MonoBehaviour
{

    public GameObject Countdown_;
    public AudioSource getReady;
    public AudioSource goAudio;
    public AudioSource inGameMusic;
    public GameObject SchrankeZU;
	public GameObject SchrankeOFFEN;
    public GameObject WRUserLabel;
    public GameObject WRmin;
    public GameObject WRsec;
    public GameObject WRmilli;
	public GameObject LapTimeManager;
    
    
    public GameObject WRInput;
    public GameObject WRSubmit;
    public GameObject newWRLabel;
	
	private Music music;
    
    public static WorldRecord WR = new WorldRecord("no Internet Connection", 00,00,0);
	
	public static RecordObject Rec = new RecordObject(new [] {"no internet connection"}, new [] {9,9,9,9,9,9,9,9,9,9},new [] {9,9,9,9,9,9,9,9,9,9},new [] {9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f});
    
    
    // Start is called before the first frame update
    void Start()
    {
		//INIT RECORD OBJECT
		/*
		int[] min = {1,2,3,4,5,6,7,8,9,10};
		int[] sec = {10,9,8,7,6,5,4,3,2,1};
		float[] milli = {1.1f,2.2f,3.3f,4.4f,5.5f,6.6f,7.7f,8.8f,9.9f,9.9f};
		string[] username = {"test1","test2","test3","test4","test5","test6","test7","test8","test9","test10"};
		 
	    RecordObject Rec = new RecordObject(username,min,sec,milli);
		RestClient.Put("https://tamischesummerfetzn.firebaseio.com/track1.json", Rec);*/
        
		WRInput.SetActive(false);
    	WRSubmit.SetActive(false);
        newWRLabel.SetActive(false);
        	
    	WRUserLabel.GetComponent<Text>().text = "" + WR.username;
    	
        if(WR.sec <= 9)
        {
             WRsec.GetComponent<Text>().text = "0" + WR.sec + ".";
        }
        else
    	{
            WRsec.GetComponent<Text>().text = "" + WR.sec + ".";
    	}

    	if(WR.min <= 9)
    	{
            WRmin.GetComponent<Text>().text = "0" + WR.min + ":";
    	}
    	else
    	{
            WRmin.GetComponent<Text>().text = "" + WR.min + ":";
		}

    	WRmilli.GetComponent<Text>().text = "" + WR.milli;
		    
    	checkWR();
    	
    	StartCoroutine(CountStart());    
    }
    
    IEnumerator CountStart()
    {
    	yield return new WaitForSeconds(0.5f);
    	Countdown_.GetComponent<Text> ().text = "3";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);
    	Countdown_.GetComponent<Text> ().text = "2";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);
    	Countdown_.GetComponent<Text> ().text = "1";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);	
    	goAudio.Play();
    	SchrankeZU.SetActive(false);
    	SchrankeOFFEN.SetActive(true);
		LapTimeManager.SetActive(true);
		inGameMusic.Play();
    }
    
    void checkWR()
    {
        RestClient.Get<RecordObject>("https://tamischesummerfetzn.firebaseio.com/trackHalloween.json").Then(response =>
        {
        Rec = response;
        WRUserLabel.GetComponent<Text>().text = "" + Rec.username[0];
    	    
        if(Rec.sec[0] <= 9)
        {
             WRsec.GetComponent<Text>().text = "0" + Rec.sec[0] + ".";
        }
        else
    	{
            WRsec.GetComponent<Text>().text = "" + Rec.sec[0] + ".";
    	}

    	if(Rec.min[0] <= 9)
    	{
            WRmin.GetComponent<Text>().text = "0" + Rec.min[0] + ":";
    	}
    	else
    	{
            WRmin.GetComponent<Text>().text = "" + Rec.min[0] + ":";
		}
    	WRmilli.GetComponent<Text>().text = "" + Rec.milli[0];
    	    
        });
    }
    
}
