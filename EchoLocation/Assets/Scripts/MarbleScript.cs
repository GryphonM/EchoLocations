using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public float speedToMakeNoise;
    public float rollSpeed = 0.2f;
    Rigidbody rb;
    public float rbVelocity;
    public float AntiNoiseSpamTimer;
    [SerializeField]
    GameObject light;
    bool delayOver = true;
    SoundPlayer soundThing;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        soundThing = this.GetComponent<SoundPlayer>();
        source = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
        //ball wont move unless i do this nonsense \/
        rb.isKinematic = true;
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        rbVelocity = rb.velocity.magnitude;
        if (rbVelocity > rollSpeed)
        {
            light.SetActive(true);
            if (!source.isPlaying)
                source.Play();
        }
        else
        {
            light.SetActive(false);
            if (source.isPlaying)
                source.Stop();
        }
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
