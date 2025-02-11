using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;  // Reference to the GameOverCanvas
    public GameObject explosionPrefab; // Reference to the explosion prefab

    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverCanvas not assigned in GameOverManager!");
        }
    }

    // Method to trigger game-over sequence
    public void TriggerGameOver(Vector3 playerPosition)
    {
        Instantiate(explosionPrefab, playerPosition, Quaternion.identity); // Spawn explosion
        StartCoroutine(GameOverSequence()); // Start Game Over sequence
    }

    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSecondsRealtime(1f); // Wait for explosion animation
        gameOverCanvas.SetActive(true);  // Show Game Over screen
        Time.timeScale = 0f;  // Pause the game
    }

    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }
}