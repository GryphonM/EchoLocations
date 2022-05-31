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
    float minStepTime;
    [SerializeField]
    float maxStepTime;
    [SerializeField]
    KeyCode staffKey = KeyCode.Mouse0;
    [SerializeField]
    GameObject Camera;

    public bool hasShoes;
    public bool hasStaff;

    Rigidbody myRB;
    Vector2 rotation;
    PlayerSound source;
    float stepTimer;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        source = GetComponent<PlayerSound>();
        Cursor.lockState = CursorLockMode.Locked;
        rotation = new Vector2(transform.rotation.x, Camera.transform.rotation.y);
        stepTimer = Random.Range(minStepTime, maxStepTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        MovePlayer();
        Staff();
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
            Footstep();
    }

    void Staff()
    {
        if (hasStaff && Input.GetKeyDown(staffKey))
        {
            source.PlayTap();
        }
    }

    void Footstep()
    {
        if (hasShoes)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0)
            {
                source.PlayFootstep();
                stepTimer = Random.Range(minStepTime, maxStepTime);
            }
        }
    }
}
