using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float maxAngle;
    [SerializeField]
    Vector3 rotationDir;
    float currentAngleX = 0;
    float currentAngleZ = 0;
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
        rotationDir = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
        //clamp x rot
        if (currentAngleX > maxAngle)
        {
            rotationDir.x = Mathf.Clamp(rotationDir.x, -1, 0);
        }
        if (currentAngleX < -maxAngle)
        {
            rotationDir.x = Mathf.Clamp(rotationDir.x, 0, 1);
        }

        //clamp z rot
        if (currentAngleZ > maxAngle)
        {
            rotationDir.z = Mathf.Clamp(rotationDir.z, -1, 0);
        }
        if (currentAngleZ < -maxAngle)
        {
            rotationDir.z = Mathf.Clamp(rotationDir.z, 0, 1);
        }
    }

    void rotateObject()
    {
        transform.Rotate(rotationDir * rotationSpeed * Time.deltaTime);
        currentAngleX += (rotationDir.x * rotationSpeed * Time.deltaTime);
        currentAngleZ += (rotationDir.z * rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, originalY, transform.eulerAngles.z);
    }
}

