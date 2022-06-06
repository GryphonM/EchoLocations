using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGate : MonoBehaviour
{
    [SerializeField]
    Safe safe;
    [SerializeField]
    float correctGateScaleMultiplier = 1.2f;
    [SerializeField]
    int ammountOfPins = 1;
    public bool isCorrectGate = false;
    public bool gateTriggered = false;
    public bool safeCracked = false;
    public AudioClip click;
    public AudioClip correct;
    public AudioClip incorrect;
    [SerializeField] float correctSize;
    float normalSize;
    SoundPlayer soundThing;
    bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        soundThing = this.GetComponent<SoundPlayer>();
        if (isCorrectGate)
        {
            soundThing.finalSize = soundThing.finalSize * correctGateScaleMultiplier;
        }
        normalSize = soundThing.finalSize;
    }
    private void Update()
    {
        if (gateTriggered)
        {
            gateTriggered = false;
            ammountOfPins -= 1;
            if (ammountOfPins <= 0)
            {
                safeCracked = true;
                safe.EndGame();
            }
            else
            {
                this.transform.parent.transform.parent.transform.rotation = Quaternion.Euler(0, 22.5f * Random.Range(4, 12), 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isSelected)
        {
            if (isCorrectGate)
            {
                soundThing.audioClips.Add(correct);
                soundThing.finalSize = correctSize;
                soundThing.PlaySound();
                soundThing.audioClips.Clear();
                soundThing.finalSize = normalSize;
                gateTriggered = true;
            }
            else
            {
                soundThing.audioClips.Add(incorrect);
                soundThing.PlaySound();
                soundThing.audioClips.Clear();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KnobPointer")
        {
            isSelected = true;
            soundThing.audioClips.Add(click);
            soundThing.PlaySound();
            soundThing.audioClips.Clear();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "KnobPointer")
        {
            isSelected = false;
        }
    }


}
