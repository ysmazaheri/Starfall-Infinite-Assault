using UnityEngine;

public class Meteor : Enemy
{
    public float fallSpeed = 2f;  // Speed at which the meteor falls downwards
    private float rotationSpeed;  // Random speed for the meteor's rotation

    void Start()
    {
        rotationSpeed = Random.Range(-50f, 50f);
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager playerHealth = collision.gameObject.GetComponent<PlayerHealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            // Get the ScoreManager and add score
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue); // Increase score by meteor's score value
            }

            Destroy(gameObject); // Destroy the meteor after collision
        }
    }
}