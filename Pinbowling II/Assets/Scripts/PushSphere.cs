using UnityEngine;
using System.Collections;

public class PushSphere : MonoBehaviour 
{
  public float PushStrength = 1.0f;
  public GameObject Aimer;

  private Rigidbody rb;

  // Use this for initialization
	void Start ()
  {
    rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
  {
    float fire = Input.GetAxis ("Fire1"); 

    if (fire > 0.0f)
    {
      rb.AddForce (Aimer.transform.forward * -1.0f * PushStrength);
    }
	}
}
