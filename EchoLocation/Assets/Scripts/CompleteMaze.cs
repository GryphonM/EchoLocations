using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMaze : MonoBehaviour
{
    [SerializeField]
    Marble smallMaze;
    [SerializeField]
    MazeRotation maze;
    [SerializeField]
    float endPause;
    [SerializeField]
    float rollWait;

    float timer;
    float rollTimer;
    bool end = false;

    private void Start()
    {
        timer = endPause;
        rollTimer = rollWait;
    }

    private void Update()
    {
        if (end)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                smallMaze.EndGame();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "bOLL")
        {
            rollTimer -= Time.deltaTime;
            if (rollTimer <= 0)
            {
                end = true;
                GetComponent<SoundPlayer>().PlaySound();
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.enabled = false;
                maze.rotationSpeed = 0;
            }
        }
    }
}
