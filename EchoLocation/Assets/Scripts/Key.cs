using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    Door targetDoor;

    public void PickUp()
    {
        targetDoor.keyCollected = true;
        Destroy(gameObject);
    }
}
