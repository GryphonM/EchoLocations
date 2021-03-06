using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public static bool inPuzzle = false;
    [SerializeField]
    protected GameObject puzzle;
    [SerializeField]
    GameObject puzzleCam;
    [SerializeField]
    protected AudioClip complete;

    protected GameObject player;
    protected SoundPlayer source;

    private void Start()
    {
        source = GetComponent<SoundPlayer>();
    }

    public void StartPuzzle(GameObject player_)
    {
        player = player_;
        player.SetActive(false);
        puzzleCam.SetActive(true);
        inPuzzle = true;
        StartGame();
    }

    public void EndPuzzle()
    {
        puzzleCam.SetActive(false);
        player.SetActive(true);
        inPuzzle = false;
    }

    public abstract void StartGame();
}
