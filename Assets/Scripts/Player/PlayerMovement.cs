using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Player movement input
    private float moveInputX;
    private float moveInputY;

    // References to the player sprite and the leaning sprites
    public Sprite defaultSprite;
    public Sprite leanLeftSprite;
    public Sprite leanRightSprite;

    private SpriteRenderer spriteRenderer;

    // Boundary GameObjects to limit player movement
    public Transform leftBoundary;
    public Transform rightBoundary;
    public Transform topBoundary;
    public Transform bottomBoundary;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get horizontal and vertical input (WASD or Arrow keys)
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");

        // Update the player movement and boundaries
        MovePlayer();

        // Update the ship's sprite based on movement direction
        UpdateShipSprite();
    }

    void MovePlayer()
    {
        // Move the player based on input
        Vector3 currentPosition = transform.position;
        currentPosition.x += moveInputX * moveSpeed * Time.deltaTime;
        currentPosition.y += moveInputY * moveSpeed * Time.deltaTime;

        // Prevent the player from moving beyond the horizontal boundaries
        float leftLimit = leftBoundary.position.x + (spriteRenderer.bounds.size.x / 2);
        float rightLimit = rightBoundary.position.x - (spriteRenderer.bounds.size.x / 2);
        currentPosition.x = Mathf.Clamp(currentPosition.x, leftLimit, rightLimit);

        // Prevent the player from moving beyond the vertical boundaries
        float topLimit = topBoundary.position.y - (spriteRenderer.bounds.size.y / 2);
        float bottomLimit = bottomBoundary.position.y + (spriteRenderer.bounds.size.y / 2);
        currentPosition.y = Mathf.Clamp(currentPosition.y, bottomLimit, topLimit);

        // Apply the updated position
        transform.position = currentPosition;
    }

    void UpdateShipSprite()
    {
        // If the player is moving to the left, change to the lean-left sprite
        if (moveInputX < 0)
        {
            spriteRenderer.sprite = leanLeftSprite;
        }
        // If the player is moving to the right, change to the lean-right sprite
        else if (moveInputX > 0)
        {
            spriteRenderer.sprite = leanRightSprite;
        }
        else
        {
            // If no horizontal movement, revert to default sprite
            spriteRenderer.sprite = defaultSprite;
        }
    }
}