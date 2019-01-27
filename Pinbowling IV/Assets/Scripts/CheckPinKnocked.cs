using UnityEngine;
using System.Collections;

public class CheckPinKnocked : MonoBehaviour 
{
  public bool IsKnocked()
  {
    return (transform.up != Vector3.up);
  }

}
