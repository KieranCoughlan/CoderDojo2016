using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour 
{
  public float StartX;
  public float EndX;
  public float Speed;

  private bool leftToRight;

 	// Use this for initialization
	void Start () 
  {
    leftToRight = StartX < EndX;

    if (leftToRight)
      ReverseTextureDirection ();

    GoToStartPosition ();
	}
	
  private void ReverseTextureDirection ()
  {
    GetComponent<Renderer> ().material.mainTextureScale = new Vector2 (-1.0f, 1.0f);
  }

  void GoToStartPosition ()
  {
    transform.position = new Vector3 (StartX, transform.position.y, transform.position.z);
  }

	// Update is called once per frame
	void Update () 
  {
    if (leftToRight == false)
    {
      transform.position -= new Vector3 (Speed, 0.0f, 0.0f);

      if (transform.position.x < EndX)
        GoToStartPosition ();
    } else
    {
      transform.position += new Vector3 (Speed, 0.0f, 0.0f);

      if (transform.position.x > EndX)
        GoToStartPosition ();
    }    
	}
}