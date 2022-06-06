using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
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
        this.gameObject.SetActive(false);
    }
}
