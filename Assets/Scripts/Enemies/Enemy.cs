using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;  // Basic health for the enemy
    public float movementSpeed = 5f;  // Basic movement speed
    public int scoreValue = 1;  // Points awarded when the enemy is destroyed
    public int contactDamage = 1;  // Damage dealt to player on contact

    protected Rigidbody2D rb;  // Rigidbody2D for movement control
    private ScoreManager scoreManager;  // Reference to the ScoreManager
    private PlayerHealthManager playerHealth; // Reference to the PlayerHealthManager

    protected virtual void Start()
    {
        // Initialize Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        
        // Set Rigidbody2D to Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        // Check if the ScoreManager was found
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene. Make sure there is a ScoreManager in the scene.");
        }
        
        // Find the PlayerHealthManager in the scene
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        // Check if the PlayerHealthManager was found
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene. Make sure there is a ScoreManager in the scene.");
        }
    }

    protected virtual void Update()
    {
        // Each specific enemy can override this with their unique movement
        Move();
    }

    protected virtual void Move()
    {
        // Default movement: move downwards
        // (directly modify position since Rigidbody is Kinematic)
        transform.position += new Vector3(0, -movementSpeed * Time.deltaTime, 0);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        // TODO: Add a visual effect like flashing or particle effects
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Update the score when the enemy dies
        scoreManager.AddScore(scoreValue);
        
        // TODO: Add a visual effect like explosion

        // Destroy object when enemy dies
        Destroy(gameObject);
    }
    
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(contactDamage);
            scoreManager.AddScore(scoreValue);
            Destroy(gameObject);
        }
        // Destroy the enemy if it collides with boundaries
        else if (collision.gameObject.CompareTag("BottomBoundary") || collision.gameObject.CompareTag("SideBoundaries"))
        {
            Destroy(gameObject);
        }
    }
    
}