using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteIngame	 : MonoBehaviour
{
  public AudioSource MusicSource;
  public GameObject RawImage;
  public static bool MuteVar = true;
  public Texture muteTexture;
  public Texture unmuteTexture;
	
  private Texture m_Texture;

  public void MuteFkt()
  {
	m_Texture = RawImage.GetComponent<RawImage>().texture;
	if(MuteVar)
	{
		MusicSource.Stop();
		m_Texture = unmuteTexture;
		RawImage.GetComponent<RawImage>().texture = m_Texture;
	}
	else
	{
		MusicSource.Play();
		m_Texture = muteTexture;
		RawImage.GetComponent<RawImage>().texture = m_Texture;
	}
	MuteVar = !MuteVar;
	
  }
}
