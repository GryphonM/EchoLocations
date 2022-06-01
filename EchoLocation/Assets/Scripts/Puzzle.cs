using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField]
    GameObject puzzle;
    [SerializeField]
    GameObject puzzleCam;

    GameObject player;

    public void StartPuzzle(GameObject player_)
    {
        player = player_;
        player.SetActive(false);
        puzzleCam.SetActive(true);
        StartGame();
    }

    public void EndPuzzle()
    {
        puzzleCam.SetActive(false);
        player.SetActive(true);
    }

    public abstract void StartGame();
}
