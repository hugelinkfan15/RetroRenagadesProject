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

    // Start is called before the first frame update
    void Start()
    {
        deathCount = 0;
        UpdateDeathCountText();
    }

    // Function to handle player death
    public void PlayerDied()
    {
        deathCount++;
        UpdateDeathCountText();
        RespawnPlayer();
    }

    // Function to respawn the player
     void RespawnPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
        player.SetActive(true);
    }

    // Function to update death count text
     void UpdateDeathCountText()
    {
        deathCountText.text = "Deaths: " + deathCount;
    }
}