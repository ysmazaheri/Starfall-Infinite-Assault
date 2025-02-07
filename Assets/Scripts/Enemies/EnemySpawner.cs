using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array to store different enemy prefabs
    public float minSpawnInterval = 0.5f;  // Minimum time between enemy spawns
    public float maxSpawnInterval = 1f;  // Maximum time between enemy spawns
    private float elapsedTime = 0f; // Time progressed in the game
    public float difficultyRampUpTime = 0.2f; // Time in seconds to ramp up difficulty
    public float spawnHeight = 6f;  // Y position where enemies will spawn (top of the screen)
    public float spawnWidth = 8f;  // Horizontal range for random spawn position

    private void Start()
    {
        // Calculate the screen width in world units and adjust the spawnWidth
        spawnWidth = Camera.main.orthographicSize * Camera.main.aspect;
        // Start spawning enemies at random intervals
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Update time progressed in game
            elapsedTime += Time.deltaTime;
            
            // Randomize spawn interval & scale difficulty based on elapsed time
            float spawnInterval = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, elapsedTime / difficultyRampUpTime);
            spawnInterval = Mathf.Clamp(spawnInterval, minSpawnInterval, maxSpawnInterval);
            Debug.Log("Spawn Inteval: " + spawnInterval);

            // Randomly select an enemy prefab to spawn
            // TODO: Implement & use SelectEnemyPrefab(), introducing different probabilities for spawning different types of enemies based on elapsed time
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Randomly select a spawn position within the spawn width
            float spawnX = Random.Range(-spawnWidth, spawnWidth);
            Vector2 spawnPosition = new Vector2(spawnX, spawnHeight);

            // Spawn the enemy at the random position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    // TODO: change enemy type (pirates, bugs, meteors) over time
    // TODO: increase the chance of spawning harder enemies over time
    /*
    private GameObject SelectEnemyPrefab()
    {
        
        if (elapsedTime < 30f)
        {
            // More common enemies
        }
        else if (elapsedTime < 60f)
        {
            // New subset of enemy prefabs
        }
        else
        {
            // All enemies
        }

        return null;
    }
    */
    
}