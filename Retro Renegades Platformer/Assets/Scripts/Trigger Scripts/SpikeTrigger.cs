using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{

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
        // For example, you might reset player position, decrease health, or trigger a death animation
        // For simplicity, let's just deactivate the player object
        player.SetActive(false);
    }
}
