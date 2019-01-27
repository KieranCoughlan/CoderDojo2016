using UnityEngine;
using System.Collections;

public class PushSphere : MonoBehaviour 
{
  public float ForceMultiplier = 1.0f;

  public float VelocityVolumeFactor = 0.1f;
  public float VelocityPitchFactor = 0.1f;

  private Rigidbody rb;
  private AudioSource audioSource;

  private Vector3 _initialPos;
  private Quaternion _initialRotation;

  // Use this for initialization
	void Start ()
  {
    rb = GetComponent<Rigidbody> ();
    audioSource = GetComponent<AudioSource> ();

    _initialPos = transform.position;
    _initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
  {
    audioSource.volume = rb.velocity.magnitude * 
                         VelocityVolumeFactor;
    audioSource.pitch = rb.velocity.magnitude * 
                        VelocityPitchFactor;
	}

  public void Push(Vector3 force)
  {
    rb.AddForce (force * ForceMultiplier);
  }

  public void Reset()
  {
    rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
    rb.angularVelocity = new Vector3 (0.0f, 0.0f, 0.0f);
    rb.position = _initialPos;
    rb.rotation = _initialRotation;
  }
}
