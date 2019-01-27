using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCube : MonoBehaviour {

  public GameManager GameManager;
  public float DestroyDelay;
  public int Score;

  void OnCollisionEnter(Collision collision)
  {
    GameManager.AddScore (Score);
    Destroy (gameObject, DestroyDelay);
  }
}
