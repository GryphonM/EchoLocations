using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = FindObjectOfType<MazeRotation>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
