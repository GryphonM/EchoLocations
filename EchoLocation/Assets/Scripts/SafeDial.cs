using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDial : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    Vector3 rotationDir;
    float originalY;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.root.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        rotateObject();
    }

    void getInput()
    {
        rotationDir = new Vector3(0, -Input.GetAxisRaw("Vertical"), 0);
    }

    void rotateObject()
    {
        transform.Rotate(rotationDir * rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
