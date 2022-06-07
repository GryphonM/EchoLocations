using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    float waitTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winScreen.SetActive(true);
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
