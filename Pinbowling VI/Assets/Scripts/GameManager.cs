using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
  public PinManager PinManager;
  public PushSphere Sphere;
  public AimerController AimerController;

  public Text ScoreText;
  public Text ShotsText;
  public Button Restart;

  public int ShotsAllowed = 3;
  public int ShotsTaken = 0;

	// Update is called once per frame
	void Update () 
  {
    ScoreText.text = string.Format ("Pins {0}/{1}", 
                                    PinManager.NumberOfFallenPins, 
                                    PinManager.NumberOfPins);
    
    ShotsText.text = string.Format ("Shots {0}/{1}", 
                                    ShotsTaken, 
                                    ShotsAllowed);

    if (ShotsTaken >= ShotsAllowed)
      Restart.gameObject.SetActive(true);
	}

  public void Reset()
  {
    ShotsTaken = 0;

    PinManager.Reset ();
    Sphere.Reset ();
    AimerController.Reset ();

    Restart.gameObject.SetActive(false);
  }
}
