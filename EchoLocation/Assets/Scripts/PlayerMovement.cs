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
            rotation.x += YInput;
        else
            rotation.x += -YInput;
        if (invertY)
            rotation.y += -XInput;
        else
            rotation.y += XInput;
        rotation.z = 0;
        Camera.transform.rotation = Quaternion.Euler(rotation * lookSpeed * Time.deltaTime);
    }

    void MovePlayer()
    {

    }
}
