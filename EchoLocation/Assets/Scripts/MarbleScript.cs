using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public float speedToMakeNoise;
    Rigidbody rb;
    public float rbVelocity;
    public float AntiNoiseSpamTimer;
    bool delayOver = true;
    SoundPlayer soundThing;
    // Start is called before the first frame update
    void Start()
    {
        soundThing = this.GetComponent<SoundPlayer>();
        rb = this.GetComponent<Rigidbody>();
        //ball wont move unless i do this nonsense \/
        rb.isKinematic = true;
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        rbVelocity = rb.velocity.magnitude; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && delayOver == true)
        {
            if (rb.velocity.magnitude > speedToMakeNoise)
            {                
                Invoke("delaySound", AntiNoiseSpamTimer);
                delayOver = false;
                soundThing.PlaySound();
            }
        }
    }

    void delaySound()
    {
        delayOver = true;
    }
}
