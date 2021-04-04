using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class Leaderboard : MonoBehaviour
{
	public GameObject LeaderboardPanel;
	public GameObject Time1;
	public GameObject Time2;
	public GameObject Time3;
	public GameObject Time4;
	public GameObject Time5;
	public GameObject Time6;
	public GameObject Time7;
	public GameObject Time8;
	public GameObject Time9;
	public GameObject Time10;
	public GameObject Username1;
	public GameObject Username2;
	public GameObject Username3;
	public GameObject Username4;
	public GameObject Username5;
	public GameObject Username6;
	public GameObject Username7;
	public GameObject Username8;
	public GameObject Username9;
	public GameObject Username10;
	
	public void ToggleLeaderboard()
	{
		LeaderboardPanel.SetActive(!LeaderboardPanel.active);
		if(LeaderboardPanel.active)
		{
			StartCoroutine(LoadLeaderBoard());
		}
	}
	
	IEnumerator LoadLeaderBoard()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
		
		RecordObject Rec = new RecordObject(new [] {"no internet connection"}, new [] {9,9,9,9,9,9,9,9,9,9},new [] {9,9,9,9,9,9,9,9,9,9},new [] {9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f,9.9f});


		RestClient.Get<RecordObject>("https://tamischesummerfetzn.firebaseio.com/trackEaster.json").Then(response =>
		{
		Debug.Log("INSIDE RESTCLIENT, Leaderboard best: " + response.username[0] + " / " + response.min[0] + " / " + response.sec[0] + " / " + response.milli[0]);
		Rec = response;
		});
			
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
		
		Time1.GetComponent<Text>().text = "" + Rec.min[0].ToString("00") + ":" + Rec.sec[0].ToString("00") + "." + Rec.milli[0].ToString().Replace(".","").Replace(",","");
		Time2.GetComponent<Text>().text = "" + Rec.min[1].ToString("00") + ":" + Rec.sec[1].ToString("00") + "." + Rec.milli[1].ToString().Replace(".","").Replace(",","");
		Time3.GetComponent<Text>().text = "" + Rec.min[2].ToString("00") + ":" + Rec.sec[2].ToString("00") + "." + Rec.milli[2].ToString().Replace(".","").Replace(",","");
		Time4.GetComponent<Text>().text = "" + Rec.min[3].ToString("00") + ":" + Rec.sec[3].ToString("00") + "." + Rec.milli[3].ToString().Replace(".","").Replace(",","");
		Time5.GetComponent<Text>().text = "" + Rec.min[4].ToString("00") + ":" + Rec.sec[4].ToString("00") + "." + Rec.milli[4].ToString().Replace(".","").Replace(",","");
		Time6.GetComponent<Text>().text = "" + Rec.min[5].ToString("00") + ":" + Rec.sec[5].ToString("00") + "." + Rec.milli[5].ToString().Replace(".","").Replace(",","");
		Time7.GetComponent<Text>().text = "" + Rec.min[6].ToString("00") + ":" + Rec.sec[6].ToString("00") + "." + Rec.milli[6].ToString().Replace(".","").Replace(",","");
		Time8.GetComponent<Text>().text = "" + Rec.min[7].ToString("00") + ":" + Rec.sec[7].ToString("00") + "." + Rec.milli[7].ToString().Replace(".","").Replace(",","");
		Time9.GetComponent<Text>().text = "" + Rec.min[8].ToString("00") + ":" + Rec.sec[8].ToString("00") + "." + Rec.milli[8].ToString().Replace(".","").Replace(",","");
		Time10.GetComponent<Text>().text = "" + Rec.min[9].ToString("00") + ":" + Rec.sec[9].ToString("00") + "." + Rec.milli[9].ToString().Replace(".","").Replace(",","");
		Username1.GetComponent<Text>().text = "" + Rec.username[0]; 
		Username2.GetComponent<Text>().text = "" + Rec.username[1]; 
		Username3.GetComponent<Text>().text = "" + Rec.username[2]; 
		Username4.GetComponent<Text>().text = "" + Rec.username[3];
		Username5.GetComponent<Text>().text = "" + Rec.username[4]; 
		Username6.GetComponent<Text>().text = "" + Rec.username[5]; 
		Username7.GetComponent<Text>().text = "" + Rec.username[6]; 
		Username8.GetComponent<Text>().text = "" + Rec.username[7]; 
		Username9.GetComponent<Text>().text = "" + Rec.username[8]; 
		Username10.GetComponent<Text>().text = "" + Rec.username[9]; 
		
    }
}
