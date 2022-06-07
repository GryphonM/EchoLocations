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
    [SerializeField]
    AudioClip open;

    [Space(10)]

    [SerializeField]
    int minClicks;
    [SerializeField]
    int maxClicks;
    [SerializeField]
    float minClickTime;
    [SerializeField]
    float maxClickTime;

    int numClicks;
    float clickTimer;
    SoundPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SoundPlayer>();
        numClicks = Random.Range(minClicks, maxClicks);
    }

    // Update is called once per frame
    void Update()
    {
        if (openBookcase)
        {
            if (numClicks <= 0)
            {
                if (Vector3.Distance(transform.position, finalPos) > 0.1f)
                    transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * speed);
                else
                    transform.position = finalPos;
            }
            else
            {
                if (clickTimer <= 0)
                {
                    player.PlaySound();
                    clickTimer = Random.Range(minClickTime, maxClickTime);
                    numClicks--;
                    if (numClicks <= 0)
                    {
                        player.PlaySound(open);
                    }
                }
                else
                    clickTimer -= Time.deltaTime;
            }
        }
    }

    public void OpenBookcase()
    {
        openBookcase = true;
    }
}
