using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Puzzle
{
    [SerializeField]
    Bookcase bookcase;
    [SerializeField]
    AudioClip ShoesDropping;

    public override void StartGame()
    {
        puzzle.SetActive(true);
    }

    public void EndGame()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        puzzle.SetActive(false);
        player.GetComponent<PlayerMovement>().hasShoes = true;
        source.PlaySound(ShoesDropping);
        StartCoroutine(SoundPlayer.PlayOneShotDelayed(complete, ShoesDropping.length, source));
        bookcase.OpenBookcase();
        EndPuzzle();
    }
}
