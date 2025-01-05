using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public HealthManager healthManager; // Reference to the health UI.
    public int health = 3; // Starting health for the player.

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthManager.TakeDamage(damage); // Update the health UI
        if (health <= 0)
        {
            // TODO: Handle player death
            // (e.g., restart the game, show game over screen, etc.)
            Debug.Log("Game Over");
        }
    }
}