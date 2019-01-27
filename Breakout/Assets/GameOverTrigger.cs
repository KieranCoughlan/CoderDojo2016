using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {

  public GameManager GameManager;

  void OnTriggerEnter(Collider other)
  {
    GameManager.GameOver = true;
  }
}
