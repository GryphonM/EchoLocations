using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Puzzle
{
    [SerializeField]
    Bookcase bookcase;

    public override void StartGame()
    {
        puzzle.SetActive(true);
    }

    public void EndGame()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        puzzle.SetActive(false);
        player.GetComponent<PlayerMovement>().hasShoes = true;
        bookcase.OpenBookcase();
        EndPuzzle();
    }
}
