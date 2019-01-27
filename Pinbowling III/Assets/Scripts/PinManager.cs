using UnityEngine;
using System.Collections;

public class PinManager : MonoBehaviour 
{
  public GameObject PinPrefab;

  public int NumberOfPins = 10;
  public int NumberOfColumns = 5;
  public int NumberOfRows = 5;

  private Vector3 _corner = new Vector3 (-3.5f, 0.0f, -3.5f);
  private float _totalWidth = 7.0f;
  private float _totalDepth = 5.0f;

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
          Quaternion rot = Quaternion.Euler (-90.0f, 0.0f, 0.0f);

          // Place pin
          Instantiate (PinPrefab, pos, rot);
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
}
