using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    float tick = 1.0f;

    float timer;
    SoundPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        timer = tick;
        player = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = tick;
            player.PlaySound();
        }
    }
}
