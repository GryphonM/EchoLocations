using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScaler : MonoBehaviour
{
    public float scalar;
    public Light lightComp;

    void Update()
    {
        //scalar = this.transform.parent.gameObject.transform.localScale.x;
        lightComp.range = ((0.0348344f * scalar) * (0.0348344f * scalar)) + (1.3437084f * scalar) - 0.5486921f;
    }
}
