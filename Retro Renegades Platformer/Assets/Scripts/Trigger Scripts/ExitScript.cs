using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

    public TMP_Text winText;
    public bool isFinalLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (isFinalLevel)
            {
                ShowWinText();
            }
            else
            {


                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }


    }
    void ShowWinText()
    {
        winText.gameObject.SetActive(true);
    }


    /* private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */
}