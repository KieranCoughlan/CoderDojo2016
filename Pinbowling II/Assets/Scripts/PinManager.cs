using UnityEngine;
using System.Collections;

public class PinManager : MonoBehaviour 
{
  public GameObject PinPrefab;

	// Use this for initialization
	void Start () 
  {
    for (int x = -1; x <= 1; x++)
    {
      for (int z = -2; z <= 0; z++)
      {
        Vector3 pos = new Vector3(x * 2, 0.5f, z * 2);

        Instantiate (PinPrefab, pos, Quaternion.identity);
      }
    }
  }
}
