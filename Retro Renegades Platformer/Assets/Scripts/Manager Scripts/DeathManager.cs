using UnityEngine;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public TMP_Text deathCountText;
    public Transform respawnPoint;
    public GameObject player;
    public int yDeathZone;
    public DeathCountData deathCountData;

    void Start()
    {
        UpdateDeathCountText();
    }

    void Update()
    {
        if (player.transform.position.y < yDeathZone)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        deathCountData.IncrementDeathCount();
        UpdateDeathCountText();
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPoint.position;
        player.SetActive(true);
    }

    void UpdateDeathCountText()
    {
        deathCountText.text = "Deaths: " + deathCountData.deathCount;
    }
}
