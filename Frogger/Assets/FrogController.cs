using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {

  public float MoveUnit;

	// Use this for initialization
	void Start () 
  {
		
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (Input.GetKey (KeyCode.RightArrow))
      transform.position += new Vector3 (MoveUnit, 0.0f, 0.0f);
    else if (Input.GetKey (KeyCode.LeftArrow))
      transform.position += new Vector3 (-MoveUnit, 0.0f, 0.0f);
    else if (Input.GetKey (KeyCode.UpArrow))
      transform.position += new Vector3 (0.0f, 0.0f, MoveUnit);
    else if (Input.GetKey (KeyCode.DownArrow))
      transform.position += new Vector3 (0.0f, 0.0f, -MoveUnit);

	}
}
