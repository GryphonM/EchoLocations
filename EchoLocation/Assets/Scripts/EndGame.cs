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

    bool end = false;

    private void Update()
    {
        if (end)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winScreen.SetActive(true);
            end = true;
            FindObjectOfType<MenuManager>(true).PauseGame();
            Time.timeScale = 1;
        }
    }
}
