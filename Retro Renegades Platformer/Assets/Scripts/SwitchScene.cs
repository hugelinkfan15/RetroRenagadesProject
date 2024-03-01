using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwitchScene : MonoBehaviour
{
    public SceneAsset selectedScene;

  public void switchScene()
    {
        SceneManager.LoadScene(selectedScene.name);
       
    }
}
