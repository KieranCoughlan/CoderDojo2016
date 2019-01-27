using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class SelectTarget : MonoBehaviour 
{
  public AICharacterControl CharacterControl;

  public Transform [] Targets;

  private int _numTargets;
  private int _currentTarget;


	// Use this for initialization
	void Start () 
  {
    _numTargets = Targets.GetLength (0);
    _currentTarget = 0;

    CharacterControl.target = Targets [_currentTarget];
	}
	
	// Update is called once per frame
	void Update () 
  {
    if (Input.GetKey (KeyCode.Space))
      NextTarget ();
	}

  void NextTarget()
  {
    _currentTarget++;

    if (_currentTarget >= _numTargets)
      _currentTarget = 0;

    CharacterControl.target = Targets [_currentTarget];
  }

}
