using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
	
	public void LoadMenu()
    {
		SceneManager.LoadScene("StartScene");
    }
	
	public void PlayTrack1()
    {
		SceneManager.LoadScene("Track_Easter");
    }
}
