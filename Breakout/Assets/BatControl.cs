using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour 
{
  public float MaxDisplacement;
  public float Speed;

	// Use this for initialization
	void Start () 
  {
		
	}
	
	// Update is called once per frame
	void Update () 
  {
    float horiz = Input.GetAxis ("Horizontal");
    float newx = transform.position.x;

    if (horiz > 0 && transform.position.x < MaxDisplacement)
      newx += Speed * horiz * Time.deltaTime;
    else if (horiz < 0 && transform.position.x > -MaxDisplacement)
      newx += Speed * horiz * Time.deltaTime;
	
    transform.position = new Vector3 (newx,
                                      transform.position.y, 
                                      transform.position.z);
  }
}
