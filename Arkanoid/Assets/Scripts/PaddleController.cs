using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float xBorder;

    private float xPosition;

    void Start()
    {
        // Set xPosition starting position
        xPosition = transform.position.x;
    }

    void Update()
    {
        // Move with arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xPosition += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xPosition -= moveSpeed * Time.deltaTime;
        }

        // Limit my xPosition
        xPosition = Mathf.Clamp(xPosition, -xBorder, xBorder);

        // Create temporary variable myPosition and update it with xPosition
        Vector2 myPosition = transform.position;
        myPosition.x = xPosition;

        // Update my actual position with the temporary variable
        transform.position = myPosition;
    }
}
