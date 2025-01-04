using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool useMouseControl = false;

    void Update()
    {
        if (useMouseControl)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveX, moveY, 0);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}