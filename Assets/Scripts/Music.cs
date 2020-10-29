using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour 
{
	
	static Music instance = null;
	
	public GameObject MuteBtn;
    
	
	// Start is called before the first frame update
	private void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
    // Update is called once per frame
	public void ToggleSound()
	{
		if(PlayerPrefs.GetInt("Muted", 0) == 0)
		{
			PlayerPrefs.SetInt("Muted",1);
			GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;	
			MuteBtn.GetComponent<Text>().text = "UNMUTE";
		}
		else
		{
			PlayerPrefs.SetInt("Muted",0);
			GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;	
			MuteBtn.GetComponent<Text>().text = "MUTE";
		}
	}
	
	public void StartSound()
	{
		GetComponent<AudioSource>().Play(0);	
	}
}
