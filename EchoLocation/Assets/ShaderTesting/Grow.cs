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
    bool startFading = false;
    // Start is called before the first frame update
    void Start()
    {
        oldIntensity = lightScaler.lightComp.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x >= finalSize)
        {
            if (startFading)
            {
                lightScaler.lightComp.intensity = lightScaler.lightComp.intensity * dimSpeed;
                if (lightScaler.lightComp.intensity <= 0.1)
                {
                    timer = 0;
                    float scale = 1 - (1 - timer) * (1 - timer);
                    this.transform.localScale = new Vector3(scale, scale, scale);
                    lightScaler.lightComp.intensity = oldIntensity;
                    startFading = false;
                }
            }
            else
                Invoke("linger", lingerDuration);
        
        }
        else
        {
            lightScaler.scalar = timer;
            timer += Time.deltaTime * speed;
            this.transform.localScale = new Vector3(timer, timer, timer);
        }
    }

    void linger()
    {
        startFading = true;
    }
}
