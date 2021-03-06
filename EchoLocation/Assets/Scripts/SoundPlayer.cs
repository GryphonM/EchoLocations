using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;
    [SerializeField]
    protected GameObject soundSource;
    [SerializeField]
    bool parent;
    [SerializeField]
    bool ignoreChecks = false;
    [SerializeField]
    Vector3 offset;

    [Space(10)]

    [SerializeField]
    protected float speed = 1;
    [SerializeField]
    public float finalSize = 1;
    [SerializeField]
    protected float lingerDuration = 1;
    [SerializeField]
    protected float dimSpeed = 1;

    public void PlaySound()
    {
        PlaySound(audioClips[Random.Range(0, audioClips.Count - 1)]);
    }

    public void PlaySound(AudioClip clip)
    {
        GameObject sound = Instantiate(soundSource);
        sound.transform.position = transform.position + offset;
        sound.GetComponent<AudioSource>().PlayOneShot(clip);
        sound.GetComponent<Grow>().speed = speed;
        sound.GetComponent<Grow>().finalSize = finalSize;
        sound.GetComponent<Grow>().lingerDuration = lingerDuration;
        sound.GetComponent<Grow>().dimSpeed = dimSpeed;
        sound.GetComponent<Grow>().ignoreChecks = ignoreChecks;
        if (parent)
            sound.transform.SetParent(transform);
    }

    public static IEnumerator PlayOneShotDelayed(AudioClip clip, float delay, SoundPlayer source)
    {
        yield return new WaitForSeconds(delay);
        source.PlaySound(clip);
    }
}
