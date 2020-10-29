using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class VersionCheck : MonoBehaviour
{
	public static string VersionNR = "2.01";
    public GameObject VersionDisplay;
	public GameObject newVersionPanel;
	
    // Start is called before the first frame update
    void Start()
    {
		VersionDisplay.GetComponent<Text>().text = "" + VersionNR;
		
		string newestVersion = "0";
		
		RestClient.Get("https://tamischesummerfetzn.firebaseio.com/version.json").Then(response =>
		{
			newestVersion =  response.Text;
			Debug.Log("newer version: " + response.Text);
					
			if(newestVersion == "0" || newestVersion != VersionNR)
			{
				
				Debug.Log("found a newer version: " + newestVersion);
				newVersionPanel.SetActive(true);
			}
		});
		
    }
	
	
}
