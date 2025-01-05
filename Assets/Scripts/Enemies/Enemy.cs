using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;  // Basic health for the enemy
    public float movementSpeed = 5f;  // Basic movement speed
    public int scoreValue = 100;  // Points awarded when the enemy is destroyed

    private Rigidbody2D rb;  // Rigidbody2D for movement control
    private ScoreManager scoreManager;  // Reference to the ScoreManager

    protected virtual void Start()
    {
        // Initialize Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    protected virtual void Update()
    {
        // Each specific enemy can override this with their unique movement
        Move();
    }

    protected virtual void Move()
    {
        // Default movement: move downwards
        Vector2 movement = new Vector2(0, -movementSpeed * Time.deltaTime);
        rb.linearVelocity = movement;
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

        // Destroy object when enemy dies
        Destroy(gameObject);
    }
}