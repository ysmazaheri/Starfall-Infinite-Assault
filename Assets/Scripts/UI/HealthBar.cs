using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> healthSegments; // List to hold each health segment GameObject

    private int currentHealth;

    void Start()
    {
        currentHealth = healthSegments.Count;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        for (int i = 0; i < healthSegments.Count; i++)
        {
            SpriteRenderer renderer = healthSegments[i].GetComponent<SpriteRenderer>();
            if (i < currentHealth)
            {
                renderer.enabled = true; // Show segment by enabling the renderer.
            }
            else
            {
                renderer.enabled = false; // Hide segment by disabling the renderer.
            }
        }
    }
}