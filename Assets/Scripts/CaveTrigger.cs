using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveTrigger : MonoBehaviour
{
    public GameObject Cave;
	public AudioSource triggerAudio;

    void OnTriggerEnter()
    {
    	 Debug.Log("Cave Trigger passed");
		 Cave.SetActive(true);
		 triggerAudio.Play();
    }
}
