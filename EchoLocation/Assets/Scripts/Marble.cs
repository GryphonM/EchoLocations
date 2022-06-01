using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Puzzle
{
    public float waitTime;
    public float timer;

    bool gameActive = false;

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
                EndGame();
        }
    }

    public override void StartGame()
    {
        gameActive = true;
    }

    public void EndGame()
    {
        gameActive = false;
        gameObject.tag = "";
        EndPuzzle();
    }
}
