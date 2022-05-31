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
    Vector2 rotation;
    AudioSource source;
    bool startedAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        rotation = new Vector2(transform.rotation.x, Camera.transform.rotation.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        MovePlayer();
    }

    void MoveCamera()
    {
        float XInput = Input.GetAxis("Mouse X") * lookSpeed;
        float YInput = Input.GetAxis("Mouse Y") * lookSpeed;

        //Vector3 rotation = Camera.transform.rotation.eulerAngles;
        if (invertY)
            rotation.x += YInput;
        else
            rotation.x += -YInput;
        if (invertY)
            rotation.y += -XInput;
        else
            rotation.y += XInput;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotation.y, 0));
        Camera.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 0, 0));
    }

    void MovePlayer()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input *= Time.deltaTime * speed;
        input = transform.TransformDirection(input);
        myRB.position += input;

        if (input.x != 0 || input.z != 0)
        {
            if (!startedAudio)
            {
                source.Play();
                startedAudio = true;
            }
        }
        else
        {
            source.Stop();
            startedAudio = false;
        }
    }
}
