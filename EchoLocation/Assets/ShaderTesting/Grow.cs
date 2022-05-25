using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float finalSize = 1;
    [SerializeField]
    float lingerDuration = 1;
    [SerializeField]
    float dimSpeed = 1;
    [SerializeField]
    LightScaler lightScaler;
    float timer;
    float timer2;
    float oldIntensity;
    float startSize;
    bool startFading = false;
    // Start is called before the first frame update
    void Start()
    {
        oldIntensity = lightScaler.lightComp.intensity;
        startSize = transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (startFading)
        {
            lightScaler.scalar = timer;
            timer -= Time.deltaTime * dimSpeed;
            transform.localScale = new Vector3(timer, timer, timer);
            if (transform.localScale.x <= startSize)
            {
                timer = 0;
                transform.localScale = new Vector3(startSize, startSize, startSize);
                lightScaler.lightComp.intensity = oldIntensity;
                startFading = false;
            }
        }
        else
        {
            if (this.transform.localScale.x >= finalSize)
            {
                Invoke("linger", lingerDuration);
            }
            else
            {
                lightScaler.scalar = timer;
                timer += Time.deltaTime * speed;
                this.transform.localScale = new Vector3(timer, timer, timer);
            }
        }
    }
    void linger()
    {
        startFading = true;
    }
}
