using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    GameObject puzzle;
    [SerializeField]
    Camera puzzleCam;

    Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPuzzle(GameObject player)
    {
        player.GetComponent<PlayerMovement>().inPuzzle = true;
        playerCam = Camera.main;
    }
}
