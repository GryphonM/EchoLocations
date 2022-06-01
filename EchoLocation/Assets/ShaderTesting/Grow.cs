using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float speed = 1;
    public float finalSize = 1;
    public float lingerDuration = 1;
    public float dimSpeed = 1;
    [SerializeField]
    LightScaler lightScaler;
    [SerializeField]
    bool loop = false;
    [HideInInspector]
    public bool ignoreChecks = false;
    float timer;
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
                if (loop)
                {
                    timer = 0;
                    transform.localScale = new Vector3(startSize, startSize, startSize);
                    lightScaler.lightComp.intensity = oldIntensity;
                    startFading = false;
                }
                else
                    Destroy(gameObject);
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
