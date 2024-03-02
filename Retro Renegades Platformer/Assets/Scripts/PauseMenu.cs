using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf)
            {
                resumeGame();
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
                isPaused = true;
            }
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
    }
}
