using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{

    public DeathManager deathManager;

    // Function called when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Call a function to handle player death
            KillPlayer(other.gameObject);
            deathManager.PlayerDied();  // Call PlayerDied() from DeathManager
        }
    }

    // Function to handle player death
    private void KillPlayer(GameObject player)
    {
        // For example, you might reset player position, decrease health, or trigger a death animation
        // For simplicity, let's just deactivate the player object
        player.SetActive(false);
    }
}
