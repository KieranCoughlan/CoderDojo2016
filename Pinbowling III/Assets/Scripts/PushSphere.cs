using UnityEngine;
using System.Collections;

public class PushSphere : MonoBehaviour 
{
  public float PushStrength = 1.0f;
  public GameObject Aimer;

  public float VelocityVolumeFactor = 0.1f;
  public float VelocityPitchFactor = 0.1f;

  private Rigidbody rb;
  private AudioSource audioSource;

  // Use this for initialization
	void Start ()
  {
    rb = GetComponent<Rigidbody> ();
    audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
  {
    float fire = Input.GetAxis ("Fire1"); 

    if (fire > 0.0f)
    {
      rb.AddForce (Aimer.transform.forward * -1.0f * PushStrength);
    }

    audioSource.volume = rb.velocity.magnitude * 
                         VelocityVolumeFactor;
    audioSource.pitch = rb.velocity.magnitude * 
                        VelocityPitchFactor;
	}
}
