using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGate : MonoBehaviour
{
    [SerializeField]
    float correctGateScaleMultiplier = 1.2f;
    [SerializeField]
    int ammountOfPins = 1;
    public bool isCorrectGate = false;
    public bool gateTriggered = false;
    public bool safeCracked = false;
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
            }
            else
            {
                this.transform.parent.transform.rotation = Quaternion.Euler(0, 22.5f * Random.Range(4, 12), 0);
            }
        }
        if (isCorrectGate && Input.GetKeyDown(KeyCode.E) && isSelected)
        {
            soundThing.PlaySound();
            gateTriggered = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KnobPointer")
        {
            isSelected = true;
            soundThing.PlaySound();
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
