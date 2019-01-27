using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
  public string ThrustAxis = "Vertical";
  public string TurnAxis = "Horizontal";

  public float ThrustStrength;
  public float TurnStrength;

  public float ThresholdVelocity;

  public bool DisableControls = false;

  public int Score { get { return _score; }}

  private Rigidbody _rb;
  private Text _text;
  private int _score;
  private GameManager _gm;

	// Use this for initialization
	void Awake () 
  {
    _rb = GetComponent<Rigidbody> ();
    _text = GetComponentInChildren<Text> ();
    _gm = FindObjectOfType<GameManager> ();
 	}

  public void SetScore(int score)
  {
    _score = score;
    _text.text = score.ToString ();
  }
	
	// Update is called once per frame
	void Update () 
  {
    if (DisableControls == true)
      return;

    float turn = Input.GetAxis (TurnAxis);
    float thrust = Input.GetAxis (ThrustAxis);

    _rb.AddForce (transform.forward * thrust * ThrustStrength);
    _rb.AddTorque (transform.up * turn * TurnStrength);
	}

  void OnCollisionEnter(Collision collision)
  {
    // We have hit something, is it another player?
    if (collision.gameObject.tag != "Player")
      return;

    // The point of contact has to be forward of 
    // us and backwards of them to register a hit
    Vector3 centreToContact = collision.contacts[0].point - transform.position;

    bool forward = Vector3.Dot(transform.forward, centreToContact) > 0;

    if (forward == false)
      return;

    bool backOfOther = Vector3.Dot(collision.gameObject.transform.forward, centreToContact) > 0;

    if (backOfOther == false)
      return;

    // Fast enough?
    if (collision.relativeVelocity.magnitude < ThresholdVelocity)
      return;

    // Register a hit
    _gm.RegisterHit(this, collision.gameObject.GetComponent<PlayerController>());
  }
}
