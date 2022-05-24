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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        rotateObject();
    }

    void getInput()
    { 
        rotationDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //clamp x rot
        if (currentAngleX > maxAngle)
        {
            rotationDir = new Vector3(Mathf.Clamp(rotationDir.x, -1, 0), rotationDir.y, rotationDir.z);
        }
        else if (currentAngleX < -maxAngle)
        {
            rotationDir = new Vector3(Mathf.Clamp(rotationDir.x, 0, 1), rotationDir.y, rotationDir.z);
        }

        //clamp z rot
        if (transform.rotation.eulerAngles.z > maxAngle)
        {
            rotationDir = new Vector3(Mathf.Clamp(rotationDir.x, -1, 0), rotationDir.y, rotationDir.z);
        }
        else if (transform.rotation.eulerAngles.z < -maxAngle)
        {
            rotationDir = new Vector3(Mathf.Clamp(rotationDir.x, 0, 1), rotationDir.y, rotationDir.z);
        }
    }

    void rotateObject()
    {
        transform.Rotate(rotationDir * rotationSpeed * Time.deltaTime);
        currentAngleX = (rotationDir.x * rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.y);
      
    }

}

