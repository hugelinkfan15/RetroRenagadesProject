using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{

    public GameObject CorpsePlatform;
    public DeathManager deathManager;

    // Function called when something enters the trigger collider
     void OnTriggerEnter2D(Collider2D collison)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (collison.gameObject.tag == ("Player"))
        {
            // Call a function to handle player death
            KillPlayer(collison.gameObject);
            deathManager.PlayerDied();  // Call PlayerDied() from DeathManager
        }
    }

    // Function to handle player death
     void KillPlayer(GameObject player)
    {
        
        player.SetActive(false);
        SpawnCorpsePlatform(player.transform.position);
    }
    void SpawnCorpsePlatform(Vector2 position)
    {
        float yOffset = -0.8f;

        Vector3 spawnPosition = new Vector3(position.x, position.y + yOffset);
        GameObject newCorpsePlatform = Instantiate(CorpsePlatform, spawnPosition, Quaternion.identity);

        //newCorpsePlatform.layer = LayerMask.NameToLayer("Ground");

    }
}
