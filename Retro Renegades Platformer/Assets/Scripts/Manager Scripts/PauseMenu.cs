using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject menu;
    public static bool isPaused;

    void Start()
    {
        menu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        //AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeSelf)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        //AudioListener.pause = false;
        isPaused = false;
    }

    public void pauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        //AudioListener.pause = true;
        isPaused = true;
    }
}
