using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> audioClips;
    [SerializeField]
    GameObject soundSource;

    [Space(10)]

    [SerializeField]
    float speed = 1;
    [SerializeField]
    float finalSize = 1;
    [SerializeField]
    float lingerDuration = 1;
    [SerializeField]
    float dimSpeed = 1;

    public void PlaySound()
    {
        GameObject sound = Instantiate(soundSource);
        sound.transform.position = transform.position;
        sound.GetComponent<AudioSource>().clip = audioClips[Random.Range(0, audioClips.Count - 1)];
        sound.GetComponent<AudioSource>().Play();
        sound.GetComponent<Grow>().speed = speed;
        sound.GetComponent<Grow>().finalSize = finalSize;
        sound.GetComponent<Grow>().lingerDuration = lingerDuration;
        sound.GetComponent<Grow>().dimSpeed = dimSpeed;
    }
}
