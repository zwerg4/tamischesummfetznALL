using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
  public GameObject StartTrigg;
  public GameObject EndTrigg;
  
  void onTriggerEnter()
  {
	Debug.Log("ONTRIGGER ENTER START");
  	EndTrigg.SetActive(true);
  	StartTrigg.SetActive(false);
  }
}
