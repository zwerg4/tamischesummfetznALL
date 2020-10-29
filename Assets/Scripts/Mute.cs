using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
  public GameObject MusicSource;
  
  public static bool MuteVar = false;

  public void MuteFkt()
  {
	MuteVar = !MuteVar;
	MusicSource.GetComponent<AudioSource>().mute = !MusicSource.GetComponent<AudioSource>().mute;	
  }
}
