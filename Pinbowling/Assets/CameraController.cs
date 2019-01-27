using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
  public GameObject Target;

  private Vector3 displacement;

	// Use this for initialization
	void Start () 
  {
    displacement = transform.position - Target.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
  {
    transform.position = Target.transform.position + displacement;
	}
}
