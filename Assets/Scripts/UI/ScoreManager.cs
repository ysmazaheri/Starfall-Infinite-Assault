using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public List<GameObject> digitGameObjects; // List to hold each digit GameObject
    public Sprite[] numberSprites; // Array to hold number options (Numbers 0-9)
    private int currentScore;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        string scoreString = currentScore.ToString().PadLeft(digitGameObjects.Count, '0');

        for (int i = 0; i < digitGameObjects.Count; i++)
        {
            int digit = int.Parse(scoreString[i].ToString());
            SpriteRenderer spriteRenderer = digitGameObjects[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = numberSprites[digit];
        }
    }
}