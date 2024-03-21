using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    public static Dictionary<int, bool> levelTracker = new Dictionary<int, bool> { { 1, false }, { 2, false }, { 3, false } };
    [SerializeField] private GameObject[] levelButtons;
    // Start is called before the first frame update

    public void levelFinished(int level)
    {
        levelTracker[level] = true;
    }

    public bool levelIsDone(int level)
    {
        return levelTracker[level];
    }

    private void Start()
    {
        for(int i= 0;i<levelButtons.Length; i++)
        {
            levelButtons[i].SetActive(levelTracker[i+1]);
        }
    }
}
