using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    float interactDistance;
    [SerializeField]
    KeyCode interactKey = KeyCode.E;
    [SerializeField]
    LayerMask interactMask;
    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject Camera;

    bool startPuzzle = false;
    GameObject curPuzzle;
    PlayerMovement move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startPuzzle)
        {
            Grow[] soundSources = GameObject.FindObjectsOfType<Grow>();
            bool soundsGone = soundSources.Length == 0;
            if (!soundsGone)
            {
                int count = 0;
                foreach (Grow sound in soundSources)
                {
                    if (sound.ignoreChecks)
                        count++;
                }
                if (count == soundSources.Length)
                    soundsGone = true;
            }
            if (soundsGone)
            {
                move.puzzleWait = false;
                startPuzzle = false;
                curPuzzle.GetComponent<Puzzle>().StartPuzzle(gameObject);
                canvas.SetActive(false);
            }
        }
        else
        {
            RaycastHit obj;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out obj, interactDistance, interactMask))
            {
                if (obj.collider.CompareTag("Puzzle"))
                {
                    tooltip.SetActive(true);
                    if (Input.GetKeyDown(interactKey))
                    {
                        move.puzzleWait = true;
                        startPuzzle = true;
                        curPuzzle = obj.collider.gameObject;
                    }
                }
                else if (obj.collider.CompareTag("Door"))
                {

                }
            }
        }
    }
}
