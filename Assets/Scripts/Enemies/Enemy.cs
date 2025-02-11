using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;  // Basic health for the enemy
    public float movementSpeed = 5f;  // Basic movement speed
    public int scoreValue = 1;  // Points awarded when the enemy is destroyed
    public int contactDamage = 1;  // Damage dealt to player on contact
    
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Color flashColor = Color.white; // The color to flash for damage
    private Color originalColor; // Store the original color of the enemy
    public float flashDuration = 0.1f; // How long the damage flash lasts
    
    
    protected Rigidbody2D rb;  // Rigidbody2D for movement control
    private ScoreManager scoreManager;  // Reference to the ScoreManager
    private PlayerHealthManager playerHealth; // Reference to the PlayerHealthManager

    protected virtual void Start()
    {
        // Initialize Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        
        // Set Rigidbody2D to Dynamic and disable gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;

        // Get SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found in Enemy script.");
        }
        originalColor = spriteRenderer.color;
        
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
        // Default movement: maintain constant downward velocity
        rb.linearVelocity = new Vector2(0, -movementSpeed);
    }

    public virtual void TakeDamage(float damage)
    {
        // Apply damage
        health -= damage;
        // Trigger the flashing effect
        StartCoroutine(FlashDamageEffect());
        // Check if the enemy is dead
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
    
    // Coroutine for flashing effect when the enemy takes damage
    private IEnumerator FlashDamageEffect()
    {
        // Change the sprite color to the flash color (white)
        spriteRenderer.color = flashColor;

        // Wait for the specified duration
        yield return new WaitForSeconds(flashDuration);

        // Reset the sprite color back to the original color
        spriteRenderer.color = originalColor;
    }
    
}