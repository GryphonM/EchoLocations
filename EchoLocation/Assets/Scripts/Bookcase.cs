using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : MonoBehaviour
{
    public bool openBookcase;
    [SerializeField]
    Vector3 finalPos;
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openBookcase)
        {
            if (Vector3.Distance(transform.position, finalPos) > 0.1f)
                transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * speed);
            else
                transform.position = finalPos;
        }
    }
}
