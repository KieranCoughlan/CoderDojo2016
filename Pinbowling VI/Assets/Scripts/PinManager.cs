using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PinManager : MonoBehaviour 
{
  public GameObject PinPrefab;

  public int NumberOfPins = 10;
  public int NumberOfColumns = 5;
  public int NumberOfRows = 5;

  public int NumberOfFallenPins = 0;

  public float KnockTolerance = 0.90f;

  private Vector3 _corner = new Vector3 (-3.5f, 0.5f, -3.5f);
  private float _totalWidth = 7.0f;
  private float _totalDepth = 5.0f;

  private List<GameObject> _pins = new List<GameObject> ();

	// Use this for initialization
	void Start () 
  {
    RandomLayout ();
  }

  void RandomLayout()
  {
    bool[,] grid = CalculateRandomGrid (NumberOfRows + 1, NumberOfColumns + 1, NumberOfPins);
    float deltaX = _totalWidth / NumberOfColumns;
    float deltaZ = _totalDepth / NumberOfRows;

    for (int col = 0; col <= NumberOfColumns; col++)
    {
      for (int row = 0; row <= NumberOfRows; row++)
      {
        if (grid [row, col] == true)
        {
          // Work out location and rotation
          Vector3 pos = _corner + new Vector3(deltaX * col, 0.0f, deltaZ * row);

          // Place pin
          GameObject newPin = Instantiate (PinPrefab, pos, Quaternion.identity) as GameObject;
          _pins.Add (newPin);
        }
      }
    }
  }

  void RegularLayout ()
  {
    for (int x = -1; x <= 1; x++)
    {
      for (int z = -2; z <= 0; z++)
      {
        Vector3 pos = new Vector3 (x * 2, 0.5f, z * 2);
        Instantiate (PinPrefab, pos, Quaternion.identity);
      }
    }
  }

  private bool [,] CalculateRandomGrid(int rows, int cols, int num)
  {
    bool[,] grid = new bool[rows, cols];
    int count = 0;

    // Until we have have enough items, keep generating new ones
    while (count < num)
    {
      // Pick a random row and column
      int row = Random.Range (0, rows);
      int col = Random.Range (0, cols);

      // See if there's already something there
      if (grid [row, col] == false)
      {
        // If not, mark it as something and increase the count of things we've made
        grid[row, col] = true;
        count++;
      }
    }

    return grid;
  }

  void Update()
  {
    // Check how many pins have fallen
    int numfallen = 0;

    foreach (GameObject pin in _pins)
    {
      if (CheckKnocked (pin))
        numfallen++;
    }

    NumberOfFallenPins = numfallen;
  }

  public void Reset()
  {
    // Destroy all the pins we created and clear the list
    foreach (GameObject pin in _pins)
      Destroy (pin);

    _pins.Clear ();

    // Reset the number of fallen pins
    NumberOfFallenPins = 0;

    // Build a new pin layout
    RandomLayout ();
  }

  private bool CheckKnocked(GameObject o)
  {
    // Find the pin's rigid body and see if it's more-or-less vertical
    Rigidbody rb = o.GetComponentInChildren<Rigidbody> ();

    float aligned = Vector4.Dot (rb.transform.up, Vector3.up);

    return aligned < KnockTolerance;
  }
}
