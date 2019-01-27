using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
  public GameObject PlayerPrefab;
  public int InitialScore;

  public Text GameOverText;

  private PlayerInfo[] _playerInfos;
  private List<PlayerController> _players;

  void Start()
  {
    _playerInfos = GetComponents<PlayerInfo> ();
    _players = new List<PlayerController> ();

    foreach (PlayerInfo pi in _playerInfos)
    {
      GameObject newGo = Instantiate (PlayerPrefab, pi.StartPosition) as GameObject;
      PlayerController newPc = newGo.GetComponent<PlayerController> ();
      newPc.ThrustAxis = pi.Vertical;
      newPc.TurnAxis = pi.Horizontal;
      newPc.SetScore(InitialScore);

      _players.Add (newPc);
    }

    CheckGameState ();
  }

  public void RegisterHit(PlayerController pc0, PlayerController pc1)
  {
    pc0.SetScore (pc0.Score + 1);
    pc1.SetScore (pc1.Score - 1);

    CheckGameState ();
  }

  private void CheckGameState ()
  {
    int playersWithPositiveScore = 0;

    foreach (PlayerController pc in _players)
    {
      if (pc.Score > 0)
        playersWithPositiveScore++;
    }

    bool gameOver = playersWithPositiveScore < 2;

    foreach (PlayerController pc in _players)
    {
      if (gameOver || pc.Score < 1)
        pc.DisableControls = true;
    }

    GameOverText.enabled = gameOver;
  }


}
