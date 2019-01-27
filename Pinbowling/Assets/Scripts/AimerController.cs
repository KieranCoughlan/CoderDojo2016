using UnityEngine;
using System.Collections;

public class AimerController : MonoBehaviour {

  public GameObject Aimer;
  public GameObject Sphere;

  public float AngleRate = 45.0f;

  public float ShotStrength = 100.0f;

 	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    float horiz = Input.GetAxis ("Horizontal");
    float fire = Input.GetAxis ("Fire1");

    if (horiz != 0.0f)
      transform.Rotate (Vector3.up, horiz * AngleRate * Time.deltaTime);

    if (fire != 0.0f)
      Sphere.GetComponent<Rigidbody> ().AddForce (transform.forward * ShotStrength);
	}
}
