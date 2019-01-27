using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundOnImpact : MonoBehaviour 
{
  public float VelocityVolumeFactor = 0.1f;
  public float VelocityPitchFactor = 0.1f;

  private AudioSource audioSource;

  // Use this for initialization
	void Start () 
  {
    audioSource = GetComponent<AudioSource> ();
	}
	
  void OnCollisionEnter(Collision collision)
  {
    audioSource.volume = collision.relativeVelocity.magnitude * 
                         VelocityVolumeFactor;
    audioSource.pitch = collision.relativeVelocity.magnitude * 
                        VelocityPitchFactor;

    audioSource.Play ();
  }
}
