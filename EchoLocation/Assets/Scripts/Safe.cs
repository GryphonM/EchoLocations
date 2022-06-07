using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Puzzle
{
    Bookcase bookcase;

    public override void StartGame()
    {
        puzzle.SetActive(true);
        bookcase = GetComponent<Bookcase>();
    }

    public void EndGame()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        puzzle.SetActive(false);
        player.GetComponent<PlayerMovement>().hasStaff = true;
        bookcase.openBookcase = true;
        SoundPlayer.PlayOneShotDelayed(complete, complete.length, source);
        EndPuzzle();
    }
}
