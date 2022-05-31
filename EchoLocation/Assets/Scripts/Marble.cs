using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    SoundPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        player.PlaySound();
    }
}
