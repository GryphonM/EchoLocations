using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGate : MonoBehaviour
{
    [SerializeField]
    float correctGateScaleMultiplier = 1.2f;
    public bool isCorrectGate = false;
    public bool gateTriggered = false;
    SoundPlayer soundThing;
    // Start is called before the first frame update
    void Start()
    {
        soundThing = this.GetComponent<SoundPlayer>();
        if (isCorrectGate)
        {
            soundThing.finalSize = soundThing.finalSize * correctGateScaleMultiplier;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KnobPointer")
        {
            soundThing.PlaySound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isCorrectGate && Input.GetKeyDown(KeyCode.E))
        {
            soundThing.PlaySound();
            gateTriggered = true;
        }
    }
}
