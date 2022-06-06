using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PauseGame();
    }
    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        hideUI();
    }

    void hideUI()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
