using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public HealthBar healthManager; // Reference to the health UI.
    public GameOverManager gameOverManager; // Reference to the game over manager
    public GameObject damagePrefab; // Reference to the player damage animation prefab
    public int health = 10; // Starting health for the player.
    
    
    void Start()
    {
        // Ensure GameOverManager is assigned
        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not assigned in PlayerHealthManager!");
        }
        // Ensure Damage Prefab is assigned
        if (damagePrefab == null)
        {
            Debug.LogError("DamagePrefab not assigned in PlayerHealthManager!");
        }
    }
    
    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthManager.TakeDamage(damage); // Update the health UI

        if (health > 0)
        {
            Instantiate(damagePrefab, transform.position, Quaternion.identity); // Spawn damage effect
        } else 
        {
            Die();
        }
    }
    
    // Method to trigger end of game
    private void Die()
    {
        gameOverManager.TriggerGameOver(transform.position); // Notify GameOverManager
        gameObject.SetActive(false); // Hide the player
    }
    
}