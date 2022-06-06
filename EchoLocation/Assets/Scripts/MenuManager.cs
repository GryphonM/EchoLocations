using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool paused;
    public GameObject player;
    public AudioSource ambience;
    void Start()
    {
        PauseGame();
    }
    void Update()
    {
        
    }
    public void PauseGame()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        paused = true;
        Time.timeScale = 0;
        ambience.Stop();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        ambience.Play();
        hideUI();
    }

    void hideUI()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
