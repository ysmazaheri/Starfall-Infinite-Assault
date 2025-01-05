using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;  // Damage dealt by the bullet

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an enemy, apply damage and destroy the bullet
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Deal damage to the enemy
            }

            Destroy(gameObject);  // Destroy the bullet after it hits the enemy
        }
        // Destroy the bullet if it collides with boundaries
        else if (collision.gameObject.CompareTag("TopBoundary") || collision.gameObject.CompareTag("SideBoundaries"))
        {
            Destroy(gameObject);
        }
    }
    
}