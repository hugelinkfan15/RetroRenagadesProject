using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;
    // Start is called before the first frame update

    //public TMP_Text textbox;
    //public int scoreToWin;
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (!gameOver)
         {
             textbox.text = "Press R to Restart";
         }
         if (score >= scoreToWin)
         {
             won = true;
             gameOver = true;
         }

         if(gameOver)
         {
             if (won)
             {
                 textbox.text = "You win!\nPress R to Try Again!";
             }
             else
             {
                 textbox.text = "You lose!\nPress R to Try Again!";
             }
             if(Input.GetKeyDown(KeyCode.R))
             {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
             }
         }


     */
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
