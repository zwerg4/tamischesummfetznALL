using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreEndTrigger : MonoBehaviour
{
    public GameObject PreEndTrigg;
    public GameObject EndTrigg;

    void OnTriggerEnter()
    {
    	 Debug.Log("PreEnd Trigger passed");
	 PreEndTrigg.SetActive(false);
     	 EndTrigg.SetActive(true);
    }
}
