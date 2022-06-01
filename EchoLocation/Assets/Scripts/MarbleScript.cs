using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public float speedToMakeNoise;
    Rigidbody rb;
    float timer = 0;
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
        if (!delayOver)
        {
            timer += Time.deltaTime;
        }
        if (timer > AntiNoiseSpamTimer)
        {
            delayOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (rb.velocity.magnitude > speedToMakeNoise && delayOver)
            {
                soundThing.PlaySound();
                delayOver = false;
            }
        }
    }
}
