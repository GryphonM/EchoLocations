using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    float tick = 1.0f;
    [Tooltip("Does the clock start with a full tick or at 0?")]
    [SerializeField]
    bool startFull;

    float timer;
    SoundPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        if (startFull)
            timer = tick;
        else
            timer = 0;
        player = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Puzzle.inPuzzle)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = tick;
                player.PlaySound();
            }
        }
    }
}
