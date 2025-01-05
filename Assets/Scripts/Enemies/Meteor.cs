using UnityEngine;

public class Meteor : Enemy
{
    private float rotationSpeed;  // Random speed for the meteor's rotation
    
    void Start()
    {
        // Call the base class Start to initialize Rigidbody2D, ScoreManager, and PlayerHealthManager
        base.Start();
        
        // Randomize the rotation speed for the meteor
        rotationSpeed = Random.Range(-50f, 50f);
    }

    void Update()
    {
        // Apply rotation using Rigidbody2D's angular velocity for smooth rotation
        rb.angularVelocity = rotationSpeed;
        // Calls the base method that updates linearVelocity
        base.Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}