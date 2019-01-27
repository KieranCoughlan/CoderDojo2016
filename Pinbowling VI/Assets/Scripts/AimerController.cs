using UnityEngine;
using System.Collections;

public class AimerController : MonoBehaviour {

  public float RotateSpeed = 1.0f;
  public PushSphere Sphere;
  public Transform Forward;
 	  
  public float PushStrength = 1.0f;
  public float PushChangeSpeed = 1.0f;

  public float PushStrengthMin = 0.5f;
  public float PushStrengthMax = 2.0f;

  public GameManager GameManager;

  private Vector3 _initialPos;
  private Quaternion _initialRotation;


  void Start()
  {
    _initialPos = transform.position;
    _initialRotation = transform.rotation;
  }

	// Update is called once per frame 
	void Update () 
  {
    //TrackSphere ();

    if (GameManager.ShotsTaken < GameManager.ShotsAllowed)
      HandleInput ();
  }

  void TrackSphere ()
  {
    transform.position = Sphere.transform.position;
  }

  void HandleInput ()
  {
    // Get input
    float horiz = Input.GetAxis ("Horizontal");
    float vert = Input.GetAxis ("Vertical");

    // Rotate the aimer
    transform.RotateAround (transform.position, Vector3.up, RotateSpeed * horiz * Time.deltaTime);

    // Calculate our new push strength and clamp it to our bounds
    float newPushStrength = PushStrength + (PushChangeSpeed * vert * Time.deltaTime);
    PushStrength = Mathf.Clamp (newPushStrength, PushStrengthMin, PushStrengthMax);

    // Scale the forward part of the aimer and move it so it's positioned correctly
    Transform ft = Forward.transform;
    ft.localScale = new Vector3 (ft.localScale.x, 
                                 PushStrength, 
                                 ft.localScale.z);
    ft.localPosition = new Vector3 (ft.localPosition.x, 
                                    ft.localPosition.y, 
                                    -PushStrength);

    // Fire key pressed?
    if (Input.GetKeyDown (KeyCode.Space))
    {
      Sphere.Push (transform.forward * -1 * PushStrength);
      GameManager.ShotsTaken++;
    }
  }

  public void Reset()
  {
    transform.position = _initialPos;
    transform.rotation = _initialRotation;
  }
}
