using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    float interactDistance;
    [SerializeField]
    LayerMask interactMask;
    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    GameObject Camera;

    PlayerMovement move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit obj;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out obj, interactDistance, interactMask))
        {
            if (obj.collider.CompareTag("Puzzle"))
            {

                //obj.collider.GetComponent<Puzzle>().StartPuzzle();
            }
            else if (obj.collider.CompareTag("Door"))
            {

            }
        }
    }
}
