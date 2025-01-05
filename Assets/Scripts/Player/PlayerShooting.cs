using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;  // The point from which bullets are fired.
    public float bulletSpeed = 400f;
    public float fireRate = 1f;  // Time in seconds between each shot.

    private float nextFireTime;

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;  // Reset the next shot time
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * bulletSpeed;
    }
}
