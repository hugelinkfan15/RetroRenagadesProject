using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public static int deathCount = 0;
    public TMP_Text deathCountText;
    public Transform respawnPoint;
    public GameObject player;
    public int yDeathZone;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        deathCount = 0;
        UpdateDeathCountText();
    }

    void Update()
    {
        if(player.transform.position.y < yDeathZone)
        {
            PlayerDied();
        }
    }

    /// <summary>
    /// Function to handle player death
    /// </summary>
    public void PlayerDied()
    {
        deathCount++;
        UpdateDeathCountText();
        RespawnPlayer();
    }

    /// <summary>
    /// Function to respawn the player
    /// </summary>
     void RespawnPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
        player.SetActive(true);
    }

    /// <summary>
    /// Function to update death count text
    /// </summary>
     void UpdateDeathCountText()
    {
        deathCountText.text = "Deaths: " + deathCount;
    }
}
