using UnityEngine;
using System.Collections;

public class AimerController : MonoBehaviour {

  public float RotateSpeed = 1.0f;
 	
	// Update is called once per frame 
	void Update () {
    float horiz = Input.GetAxis("Horizontal");

    transform.RotateAround (transform.position, Vector3.up, 
                            RotateSpeed * horiz * Time.deltaTime);
	}
}
