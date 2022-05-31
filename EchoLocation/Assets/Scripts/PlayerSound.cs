using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : SoundPlayer
{
    [Space(10)]

    [SerializeField]
    AudioClip staffTap;
    [SerializeField]
    protected float staffSpeed = 1;
    [SerializeField]
    protected float staffFinalSize = 1;
    [SerializeField]
    protected float staffLingerDuration = 1;
    [SerializeField]
    protected float staffDimSpeed = 1;

    public void PlayFootstep()
    {
        GameObject sound = Instantiate(soundSource, transform);
        Vector3 pos = transform.position;
        pos.y -= transform.localScale.y;
        sound.transform.position = pos;
        sound.GetComponent<AudioSource>().PlayOneShot(audioClips[Random.Range(0, audioClips.Count - 1)]);
        sound.GetComponent<Grow>().speed = speed;
        sound.GetComponent<Grow>().finalSize = finalSize;
        sound.GetComponent<Grow>().lingerDuration = lingerDuration;
        sound.GetComponent<Grow>().dimSpeed = dimSpeed;
    }

    public void PlayTap()
    {
        GameObject sound = Instantiate(soundSource);
        Vector3 pos = transform.position;
        pos.y -= transform.localScale.y;
        sound.transform.position = pos;
        sound.GetComponent<AudioSource>().PlayOneShot(staffTap);
        sound.GetComponent<Grow>().speed = staffSpeed;
        sound.GetComponent<Grow>().finalSize = staffFinalSize;
        sound.GetComponent<Grow>().lingerDuration = staffLingerDuration;
        sound.GetComponent<Grow>().dimSpeed = staffDimSpeed;
    }
}
