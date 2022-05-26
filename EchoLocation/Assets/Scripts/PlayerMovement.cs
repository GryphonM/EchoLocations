using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float lookSpeed;
    [SerializeField]
    bool invertY;
    [SerializeField]
    bool invertX;
    [SerializeField]
    GameObject Camera;

    Rigidbody myRB;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        MovePlayer();
    }

    void MoveCamera()
    {
        float XInput = Input.GetAxis("Mouse X");
        float YInput = Input.GetAxis("Mouse Y");

        Vector3 rotation = Camera.transform.rotation.eulerAngles;
        if (invertY)
            rotation.x += YInput * lookSpeed;
        else
            rotation.x += -YInput * lookSpeed;
        if (invertY)
            rotation.y += -XInput * lookSpeed;
        else
            rotation.y += XInput * lookSpeed;
        rotation.z = 0;
        Camera.transform.rotation = Quaternion.Euler(rotation);
    }

    void MovePlayer()
    {

    }
}
