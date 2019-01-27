using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public bool GameOver;
  public int Score;

  public Text ScoreText;
  public Text GameOverText;

  public GameObject CubePrefab;
  public float CubeSpacing;
  public Vector3 TopLeft;
  public int CubeRows;
  public int CubeCols;

  private int NumCubes;

	// Use this for initialization
	void Start () 
  {
    GameOver = false;
    Score = 0;

    CreateCubes ();
	}
	
	// Update is called once per frame
	void Update () 
  {
    UpdateTextFields ();
	}

  public void AddScore(int points)
  {
    Score += points;
    NumCubes--;

    if (NumCubes < 1)
      GameOver = true;
  }

  void UpdateTextFields ()
  {
    ScoreText.text = Score.ToString ();
    GameOverText.text = GameOver ? "Game Over" : "";

    if (GameOver)
    {
      if (NumCubes < 1)
        GameOverText.text = "You win";
      else
        GameOverText.text = "You lose (sad)";
    } 
    else
    {
      GameOverText.text = "";
    }
  }

  void CreateCubes()
  {
    Vector3 currentPosition = TopLeft;

    for (int i = 0; i < CubeRows; i++)
    {
      for (int j = 0; j < CubeCols; j++)
      {
        GameObject newGo = Instantiate (CubePrefab, currentPosition, 
                                        Quaternion.identity) as GameObject;
        TargetCube newTc = newGo.GetComponent<TargetCube> ();
        newTc.GameManager = this;
        NumCubes++;

        currentPosition += new Vector3 (CubeSpacing, 0.0f, 0.0f);
      }

      currentPosition -= new Vector3 (CubeSpacing * CubeCols, 0.0f, CubeSpacing);
    }
  }
}
