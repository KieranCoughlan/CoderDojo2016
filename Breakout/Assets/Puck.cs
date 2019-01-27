using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour 
{
  public float Speed;

  private Vector3 _velocity;

	// Use this for initialization
	void Start () 
  {
    float angle = Random.Range (-60.0f, 60.0f);
    _velocity = new Vector3 (Mathf.Cos (angle), 0.0f,
                             Mathf.Abs(Mathf.Sin (angle))) * Speed;
	}
	
	// Update is called once per frame
	void Update () 
  {
    Vector3 updatedPos = transform.position + (_velocity * Time.deltaTime);
    transform.position = updatedPos;
	}

  void OnCollisionEnter(Collision collision)
  {
    Vector3 hitpoint = collision.contacts [0].point;

    // Reverse the component of velocity that's in the direction of the
    // point of collision
    Vector3 directionOfCollision = (hitpoint - transform.position).normalized;
    float collisionSpeed = Vector3.Dot (_velocity, directionOfCollision);

    _velocity -= (directionOfCollision * (2.0f * collisionSpeed));
  }
}
