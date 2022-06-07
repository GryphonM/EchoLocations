using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool keyCollected = false;
    public float desiredAngle = 90;
    bool isOpen = false;
    public float lerpRate = .1f;
    [SerializeField] AudioClip unlockSound;
    [SerializeField] AudioClip openSound;
    SoundPlayer source;

    private void Start()
    {
        source = GetComponent<SoundPlayer>();
    }

    void Update()
    {
        if (isOpen == true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, desiredAngle, 0), lerpRate);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && keyCollected == true)
            {
                OpenDoor();
            }
        }

    }
    public IEnumerator OpenDoor()
    {
        if (isOpen == false)
        {
            transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
            source.PlaySound(unlockSound);
            yield return new WaitForSeconds(unlockSound.length);
            isOpen = true;
            source.PlaySound(openSound);
        }
    }
}
