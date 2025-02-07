using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public HealthBar healthManager; // Reference to the health UI.
    public GameObject gameOverCanvas;  // Reference to the GameOverCanvas.
    public int health = 10; // Starting health for the player.
    
    void Start()
    {
        // Ensure GameOverCanvas is disabled at the start
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverCanvas not assigned in PlayerHealthManager!");
        }
    }
    
    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthManager.TakeDamage(damage); // Update the health UI
        if (health <= 0)
        {
            GameOver();
        }
    }
    
    // Method to prompt game-over panel, ending game
    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;  // Pause the game
        gameOverCanvas.SetActive(true);  // Show Game Over screen
    }
    
    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }
    
}