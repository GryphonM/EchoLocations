using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Puzzle
{
    [SerializeField] AudioClip getStaff;
    AudioSource source;

    public override void StartGame()
    {
        puzzle.SetActive(true);
        source = GetComponent<AudioSource>();
    }

    public void EndGame()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        puzzle.SetActive(false);
        player.GetComponent<PlayerMovement>().hasStaff = true;
        EndPuzzle();
    }
}
