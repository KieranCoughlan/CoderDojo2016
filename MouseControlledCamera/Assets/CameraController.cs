using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public float TurnSpeed;
  public float TiltSpeed;

  private Transform tiltTransform;

	// Use this for initialization
	void Start () 
  {
    tiltTransform = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () 
  {
    float horiz = Input.GetAxis ("Horizontal");
    float vertical = Input.GetAxis ("Vertical");

    transform.Rotate(new Vector3(0.0f, 
                                 horiz * TurnSpeed * Time.deltaTime,
                                 0.0f));
    tiltTransform.Rotate(new Vector3(vertical * TiltSpeed * Time.deltaTime,
                                     0.0f,
                                     0.0f));
  
  }
}
